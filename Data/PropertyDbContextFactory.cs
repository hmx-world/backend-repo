using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using tinder4apartment.Data;

namespace server.Infrastructure.Data
{
    public class PropertyDbContexFactory : IDesignTimeDbContextFactory<PropertyDbContext>
    {
      
        public PropertyDbContext CreateDbContext(string[] args)
        {
            string ConnectDbString = "Server=tcp:startup-server.database.windows.net,1433;Initial Catalog=tinder4apartment_db;Persist Security Info=False;User ID=startupadmin;Password=Adegoke1234#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var optionsBuilder = new DbContextOptionsBuilder<PropertyDbContext>();
            optionsBuilder.UseSqlServer(ConnectDbString);

            return new PropertyDbContext(optionsBuilder.Options);
        }
    }

   
}