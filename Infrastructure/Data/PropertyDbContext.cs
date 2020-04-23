using Microsoft.EntityFrameworkCore;
using server.Core.Models;
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
        
        public DbSet<CommercialProperty> CommercialProperties {get; set;}
        public DbSet<ProviderModel> ProviderModels {get; set;}

        public DbSet<SubModel> SubModels {get; set;}
        public DbSet<SearchQueryLog> SearchQueryLogs {get; set;}
        public DbSet<EmergencyProperty> EmergencyProperties {get; set;}
        public DbSet<LandProperty> LandProperties {get; set;}
        public DbSet<GoForCheckOrRedirect> GoForCheckOrRedirects {get; set;}
      
    }
}