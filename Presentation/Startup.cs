using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using tinder4apartment.Data;
using tinder4apartment.Repo;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using server.Core.Repo;

namespace tinder4apartment
{
    public class Startup
    {
        private string ConnectDbString = "Server=tcp:startup-server.database.windows.net,1433;Initial Catalog=tinder4apartment_db;Persist Security Info=False;User ID=startupadmin;Password=Adegoke1234#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

      
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
      
        public void ConfigureServices(IServiceCollection services)
        {
         
           services.AddDbContext<PropertyDbContext>(options =>
                 options.UseSqlServer(ConnectDbString));

            // services.AddAuthentication(options => {
            //     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            // }).AddJwtBearer(options => {
            //     options.Authority = Configuration["Auth0:Domain"];
            //     options.Audience= Configuration["Auth0:Audience"];
            // });



             services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
          

            //swagger 
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo{
                    Title ="property-b2b-backend", Version ="v1"
                });
            });

            services.AddScoped<IPropertyManager, PropertyManager>();
            services.AddScoped<IMatchRepo, MatchRepo>();
            services.AddScoped<IFirmRepo, FirmRepo>();
            services.AddScoped<IBlobRepo, BlobRepo>();
            services.AddScoped<ISubscriptionRepo, SubscriptionRepo>();
            services.AddScoped<IAdminRepo, AdminRepo>();
            

            //services.AddSwaggerDocument(); 

            services.Configure<FormOptions>(options => {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });

           

             var key = Encoding.ASCII.GetBytes("SOME RANDOM WORD FOR TOKEN GENERATION");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI( c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "tinder4apartment API");
            });

           // app.UseHttpsRedirection();

            app.UseRouting();
           // app.UseCorsMiddleware();

           app.UseAuthentication();
   
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           
        }
    }
}
