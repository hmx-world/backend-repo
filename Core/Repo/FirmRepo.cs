using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using server.Core.Models;
using tinder4apartment.Data;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public class FirmRepo : IFirmRepo
    {
        private readonly PropertyDbContext _db;
        private readonly IBlobRepo _blob;
        private readonly IConfiguration _config;
        public FirmRepo(PropertyDbContext db, IBlobRepo blob, IConfiguration config)
        {
            _db = db;
            _blob = blob;
            _config = config;
        }
        public async Task<List<FirmLoginDto>> CreateFirm(Firm firmDetails)
        {
           var rnd = new RNGCryptoServiceProvider();
            var sb = new StringBuilder();
            var buf = new byte[3]; //length: should be larger
            rnd.GetBytes(buf);

            //gives a "valid" range of: "0123456789ABCDEF"   
            foreach (byte b in buf)
                sb.AppendFormat("{0:x2}", b);
             string passwordHash, passwordSalt;

           
            CreatePasswordHash(firmDetails.Password, out passwordHash, out passwordSalt);

            firmDetails.PasswordHash = passwordHash;
            firmDetails.PasswordSalt = passwordSalt;
            firmDetails.LoginId = sb.ToString();
  
            if(firmDetails.imageFile1 == null)
            {
                firmDetails.ImageUri = "#";
            }
            else{
                  var imageFileName = firmDetails.imageFile1.FileName;
                string imageMimeType =firmDetails.imageFile1.ContentType;
                byte[] imageData = PropertyManager.GetBytes(firmDetails.imageFile1);

                firmDetails.ImageUri = _blob.UploadFileToBlob(imageFileName, imageData, imageMimeType);

            }
          
            
            List<Firm> firmsCreated = ListofCreatedFirms(firmDetails);
            _db.AddRange(firmsCreated);            
           
            await _db.SaveChangesAsync();


            // return new FirmLoginDto(){
            //     LoginId = firmDetails.LoginId,
            //     Password = firmDetails.Password,
            //     Id = firmDetails.Id
            // };


           return LoginDetails(firmsCreated);
        }

        
        public Task<Firm> EditFirmInfo(Firm providerDetails, int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<FirmVitalInfo> FirmLogin(FirmLoginDto provider)
        {
            var details = await _db.Firms.FirstOrDefaultAsync(m=> m.LoginId == provider.LoginId);

            if (details != null)
            {
                if (!VerifyPassword(provider.Password, details.PasswordHash, details.PasswordSalt))
                {
                    return null;
                }
                string tokenGen = GenerateToken(details);

                var firmInfo = new FirmVitalInfo{
                    Name = details.Name,
                    Id = details.Id,
                    Token = tokenGen,
                    Email = details.Email,
                    LoginId = details.LoginId
                };

                return firmInfo;
            }

            return null;
            
        }

        public async Task<Firm> GetFirmDataComplete(int id)
        {
            var provider =  await _db.Firms.Include(m => m.OnSaleProperties)
                        .Include(m=> m.RentalProperties)
                        .Include(m => m.CommercialProperty)
                        .FirstOrDefaultAsync(m => m.Id == id);


            provider.Password = null;
            provider.PasswordSalt = null;
            provider.PasswordHash = null;

            return provider;
        }

        public async Task<List<Firm>> GetFirms()
        {
            return await _db.Firms.ToListAsync();
        }

        public void AddEmergencyProperty(EmergencyProperty emergencyProperty)
        {
            _db.EmergencyProperties.Add(emergencyProperty);
            _db.SaveChanges();
        }


        public List<Firm> ListofCreatedFirms(Firm firmdetails)
        {
           
            List<Firm> firms = new List<Firm>();
            switch (firmdetails.Plan)
            {
                case Plan.Business:
                    firms.Add(firmdetails);
                    return firms;
                case Plan.Pro:
                    firms.Add(firmdetails);
                    firms.Add(CreateFrimVariant(firmdetails, "-n"));
                    return firms;
                case Plan.Premium:
                    firms.Add(firmdetails);
                    firms.Add(CreateFrimVariant(firmdetails, "-ne"));
                    firms.Add(CreateFrimVariant(firmdetails, "-re"));
                    firms.Add(CreateFrimVariant(firmdetails, "-ze"));
                    firms.Add(CreateFrimVariant(firmdetails, "-we"));
                    return firms;
                default:
                    return firms;
            }
        }

        public List<FirmLoginDto> LoginDetails(List<Firm> firms)
        {
            List<FirmLoginDto> login = new List<FirmLoginDto>();
            foreach (var item in firms)
            {
                login.Add(new FirmLoginDto{
                    LoginId = item.LoginId,
                    Password = item.Password,
                    Id = item.Id
                });
            }

            return login;
        }

        public Firm CreateFrimVariant(Firm firm, string variant)
        {
           var newUser = new Firm{
               Name = firm.Name,
               Location = firm.Location,
               LoginId = firm.LoginId + variant,
               ImageUri = firm.ImageUri,
               Description = firm.Description,
               Email  = firm.Email,
               Password = firm.Password,
               PasswordHash = firm.PasswordHash,
               PasswordSalt = firm.PasswordSalt,
               Plan = firm.Plan,
               PhoneNumber = firm.PhoneNumber
           };

           return newUser;
        }
         public string GenerateToken(Firm userData)
        {
            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("SOME RANDOM WORD FOR TOKEN GENERATION");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { 
                    new Claim(ClaimTypes.NameIdentifier,userData.Email)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        

        private void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            passwordSalt = getSalt();
            passwordHash = getHash(passwordSalt + password);
        }


        private string getSalt()
        {
            byte[] bytes = new byte[128 / 8];
            using (var keyGenerator = RandomNumberGenerator.Create())
            {
                keyGenerator.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
        private string getHash(string text)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private bool VerifyPassword(string password, string passwordHash, string passwordSalt)
        {
            var computedHash = getHash(passwordSalt + password);
            if (!(computedHash == passwordHash))
            {
                return false;
            }
            return true;
        }

    
    }


    public class FirmVitalInfo{
        public string Name;
        public string Email;
        public int Id;
        public string Token;

        public string LoginId;
    }
}