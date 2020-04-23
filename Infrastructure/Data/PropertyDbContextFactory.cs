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
            var optionsBuilder = new DbContextOptionsBuilder<PropertyDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\v11.0;Database=hmxworld-db;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new PropertyDbContext(optionsBuilder.Options);
        }
    }

   
}