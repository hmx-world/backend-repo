using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tinder4apartment.Data;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public class PropertyManager : IPropertyManager
    {
        private readonly PropertyDbContext _db;
        public PropertyManager(PropertyDbContext db)
        {
            _db = db;
        }

        public async Task<OnSaleProperty> AddOnSaleProperty(OnSaleProperty property)
        {
            if (property != null)
            {
                _db.OnSaleProperties.Add(property);
                await _db.SaveChangesAsync();

                return property;
            }

            return null;
        }

        public async Task<RentalProperty> AddRentalProperty(RentalProperty property)
        {
             if (property != null)
            {
                _db.RentalProperties.Add(property);
                await _db.SaveChangesAsync();

                return property;
            }

            return null;
        }

        public async Task<OnSaleProperty> GetOneOnSaleProperty(int id)
        {
            return await _db.OnSaleProperties.FirstOrDefaultAsync(m=> m.Id == id);
        }

        public async Task<RentalProperty> GetOneRentalProperty(int id)
        {
            return await _db.RentalProperties.FirstOrDefaultAsync(m=> m.Id == id);
        }

        public async Task<List<OnSaleProperty>> GetAllOnSaleProperty()
        {
            return await _db.OnSaleProperties.ToListAsync();
        }

        public async Task<List<OnSaleProperty>> GetOnSalePropertyByProvider(string providerName)
        {
            return await _db.OnSaleProperties.Where(m => m.ProviderName.ToLower().Equals(providerName.ToLower())).ToListAsync();
        }

        public async Task<List<RentalProperty>> GetAllRentalProperty()
        {
            return await _db.RentalProperties.ToListAsync();
        }

        public async Task<List<RentalProperty>> GetRentalPropertyByProvider(string providerName)
        {
            return await _db.RentalProperties.Where(m => m.ProviderName.ToLower().Equals(providerName.ToLower())).ToListAsync();
        }
    }
}