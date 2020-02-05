using Microsoft.EntityFrameworkCore;
using tinder4apartment.Models;

namespace tinder4apartment.Data
{
    public class PropertyDbContext : DbContext
    {
        public PropertyDbContext(DbContextOptions<PropertyDbContext> options) : base (options)
        {
            
        }
        public DbSet<RentalProperty> RentalProperties {get;set;}      
        public DbSet<OnSaleProperty> OnSaleProperties {get; set;}  
        
        public DbSet<IndustrialProperty> IndustrialProperties {get; set;}
        public DbSet<ProviderModel> ProviderModels {get; set;}
      
    }
}