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
using tinder4apartment.Data;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public class ProviderRepo : IProviderRepo
    {
        private readonly PropertyDbContext _db;
        private readonly IBlobRepo _blob;
        private readonly IConfiguration _config;
        public ProviderRepo(PropertyDbContext db, IBlobRepo blob, IConfiguration config)
        {
            _db = db;
            _blob = blob;
            _config = config;
        }
        public async Task<ProviderLoginDto> CreateProvider(ProviderModel providerDetails)
        {
           var rnd = new RNGCryptoServiceProvider();
            var sb = new StringBuilder();
            var buf = new byte[3]; //length: should be larger
            rnd.GetBytes(buf);

            //gives a "valid" range of: "0123456789ABCDEF"   
            foreach (byte b in buf)
                sb.AppendFormat("{0:x2}", b);
             string passwordHash, passwordSalt;

           
            CreatePasswordHash(providerDetails.Password, out passwordHash, out passwordSalt);

            providerDetails.PasswordHash = passwordHash;
            providerDetails.PasswordSalt = passwordSalt;
            providerDetails.LoginId = sb.ToString();
  
            
            var imageFileName = providerDetails.imageFile1.FileName;
            string imageMimeType =providerDetails.imageFile1.ContentType;
            byte[] imageData = PropertyManager.GetBytes(providerDetails.imageFile1);

            providerDetails.ImageUri = _blob.UploadFileToBlob(imageFileName, imageData, imageMimeType);

            _db.ProviderModels.Add(providerDetails);
            await _db.SaveChangesAsync();


            return new ProviderLoginDto(){
                LoginId = providerDetails.LoginId,
                Password = providerDetails.Password,
                Id = providerDetails.Id
            };
        }

        public Task<ProviderModel> EditProviderInfo(ProviderModel providerDetails, int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ProviderVitalInfo> ProviderLogin(ProviderLoginDto provider)
        {
            var details = await _db.ProviderModels.FirstOrDefaultAsync(m=> m.LoginId == provider.LoginId);

            if (details != null)
            {
                if (!VerifyPassword(provider.Password, details.PasswordHash, details.PasswordSalt))
                {
                    return null;
                }
                string tokenGen = GenerateToken(details);

                var providerInfo = new ProviderVitalInfo{
                    Name = details.Name,
                    Id = details.Id,
                    Token = tokenGen,
                    Email = details.Email,
                    LoginId = details.LoginId
                };

                return providerInfo;
            }

            return null;
            
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

        public async Task<ProviderModel> GetProviderDataComplete(int id)
        {
            var provider =  await _db.ProviderModels.Include(m => m.OnSaleProperties)
                        .Include(m=> m.RentalProperties)
                        .Include(m => m.IndustrialProperty)
                        .FirstOrDefaultAsync(m => m.Id == id);


            provider.Password = null;
            provider.PasswordSalt = null;
            provider.PasswordHash = null;

            return provider;
        }

        public async Task<List<ProviderModel>> GetProviders()
        {
            return await _db.ProviderModels.ToListAsync();
        }

         public string GenerateToken(ProviderModel userData)
        {
            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
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
        

    }


    public class ProviderVitalInfo{
        public string Name;
        public string Email;
        public int Id;
        public string Token;

        public string LoginId;
    }
}