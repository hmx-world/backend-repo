using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tinder4apartment.Data;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public class ProviderRepo : IProviderRepo
    {
        private readonly PropertyDbContext _db;
        public ProviderRepo(PropertyDbContext db)
        {
            _db = db;
        }
        public async Task<ProviderLoginDto> CreateProvider(ProviderModel providerDetails)
        {
            Random rn = new Random();
             string passwordHash, passwordSalt;

            CreatePasswordHash(providerDetails.Password, out passwordHash, out passwordSalt);

            providerDetails.PasswordHash = passwordHash;
            providerDetails.PasswordSalt = passwordSalt;
            providerDetails.LoginId = providerDetails.Name+ (rn.Next() * 1987).ToString();
            

            _db.Add(providerDetails);
            await _db.SaveChangesAsync();


            return new ProviderLoginDto(){
                LoginId = providerDetails.LoginId,
                Password = providerDetails.Password
            };
        }

        public Task<ProviderModel> EditProviderInfo(ProviderModel providerDetails, int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> ProviderLogin(ProviderLoginDto provider)
        {
            var details = await _db.ProviderModels.FirstOrDefaultAsync(m=> m.LoginId == provider.LoginId);

            if (details != null)
            {
                if (!VerifyPassword(provider.Password, details.PasswordHash, details.PasswordSalt))
                {
                    return null;
                }
                
                string result = "login successful";

                return result;
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
            return await _db.ProviderModels.Include(m => m.OnSaleProperties)
                        .Include(m=> m.RentalProperties)
                        .Include(m => m.IndustrialProperty)
                        .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<ProviderModel>> GetProviders()
        {
            return await _db.ProviderModels.ToListAsync();
        }
    }
}