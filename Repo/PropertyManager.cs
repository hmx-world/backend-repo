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
                property.IsActive = true;
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
                property.IsActive = true;
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

        public async Task<List<OnSaleProperty>> GetAllActiveOnSaleProperty()
        {
            return await _db.OnSaleProperties.Where(m => m.IsActive == true).ToListAsync();
        }

        public async Task<List<OnSaleProperty>> GetActiveOnSalePropertyByProvider(string providerName)
        {
            return await _db.OnSaleProperties.Where(m => m.ProviderName.ToLower().Equals(providerName.ToLower()) && m.IsActive == true).ToListAsync();
        }

        public async Task<List<RentalProperty>> GetAllActiveRentalProperty()
        {
            return await _db.RentalProperties.Where(m => m.IsActive == true).ToListAsync();
        }

        public async Task<List<RentalProperty>> GetActiveRentalPropertyByProvider(string providerName)
        {
            return await _db.RentalProperties.Where(m => m.ProviderName.ToLower().Equals(providerName.ToLower()) && m.IsActive == true ).ToListAsync();
        }

        public void DeactivateProperty(int id, string mode)
        {
            switch (mode)
            {
                case "rental":
                    var rental =  _db.RentalProperties.FirstOrDefault(m => m.Id == id);
                    rental.IsActive = false;
                    _db.SaveChanges();
                    break;
                
                case "onsale":
                    var onsale = _db.OnSaleProperties.FirstOrDefault(m=> m.Id == id);
                    onsale.IsActive = false;
                    _db.SaveChanges();
                    break;
                
                case "industrial":
                    var industrial = _db.IndustrialProperties.FirstOrDefault(m=> m.Id == id);
                    industrial.IsActive = false;
                    _db.SaveChanges();
                    break;
                default:
                    break;
            }
        }

        public async Task<List<RentalProperty>> GetAllRentalProperty()
        {
            return await _db.RentalProperties.ToListAsync();
        }

        public async Task<List<OnSaleProperty>> GetAllOnSaleProperty()
        {
            return await _db.OnSaleProperties.ToListAsync();
        }

        public async Task<List<RentalProperty>> GetRentalPropertyByProvider(string providerName)
        {
            return await _db.RentalProperties.Where(m => m.ProviderName.ToLower().Equals(providerName.ToLower())).ToListAsync();
        }

        public async Task<List<OnSaleProperty>> GetOnSalePropertyByProvider(string providerName)
        {
            return await _db.OnSaleProperties.Where(m => m.ProviderName.ToLower().Equals(providerName.ToLower())).ToListAsync();
        }

        public async Task<IndustrialProperty> AddIndustrialProperty(IndustrialProperty property)
        {
             if (property != null)
            {
                property.IsActive = true;
                _db.IndustrialProperties.Add(property);
                await _db.SaveChangesAsync();

                return property;
            }

            return null;
        }

        public async Task<List<IndustrialProperty>> GetIndustrialProperty()
        {
            return await _db.IndustrialProperties.ToListAsync();
        }

        public async Task<List<IndustrialProperty>> GetIndustrialPropertyByProvider(string provider)
        {
            return await _db.IndustrialProperties.Where(m => m.ProviderName.ToLower() == provider.ToLower()).ToListAsync();
        }

        public async Task<IndustrialProperty> GetOneIndustrialProperty(int id)
        {
            return await _db.IndustrialProperties.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<IndustrialProperty>> GetActiveIndustrialProperty()
        {
            return await _db.IndustrialProperties.Where(m => m.IsActive == true).ToListAsync();
        }

        public async Task<List<IndustrialProperty>> GetActiveIndustrialPropertyByProvider(string provider)
        {
            return await _db.IndustrialProperties.Where(m => m.ProviderName.ToLower() == provider.ToLower() && m.IsActive == true).ToListAsync();
        }
    }
}