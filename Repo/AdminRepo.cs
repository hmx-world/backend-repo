using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using server.Core.Models;
using tinder4apartment.Data;
using tinder4apartment.Models;

namespace server.Core.Repo
{
    public class AdminRepo : IAdminRepo
    {
        private readonly PropertyDbContext _db;
        private readonly IConfiguration _config;
        public AdminRepo(PropertyDbContext db, IConfiguration configuration)
        {
            _db = db;
            _config =configuration;
        }
        public async Task<List<FirmDetailsDTO>> GetAllFirms()
        {
            var result = await (from firm in _db.Firms
                        select new FirmDetailsDTO {
                            Id = firm.Id,
                            LoginID = firm.LoginId,
                            FirmName = firm.Name,
                            CurrentPlan = firm.Plan.ToString(),
                            RentalProperties = firm.RentalProperties.Count,
                            LandProperties = firm.LandProperties.Count,
                            CommercialProperties = firm.CommercialProperty.Count,
                            OnSaleProperties = firm.OnSaleProperties.Count,
                            Email = firm.Email,
                            PhoneNumber = firm.PhoneNumber
                        }).ToListAsync();
            
            return result;
        }

        public List<EmergencyPropertyDTO> GetEmergencyProperties()
        {
            var result = _db.EmergencyProperties.ToList();

            List<EmergencyPropertyDTO> emergencyList = new List<EmergencyPropertyDTO>();

            foreach (var item in result)
            {
                EmergencyPropertyDTO emergencyProperty = new EmergencyPropertyDTO();
                EmergencyHelper(item.Id,item.PropertyId, item.PropertyType, out emergencyProperty);

                emergencyList.Add(emergencyProperty);
            }

            return emergencyList;

        }

        public async Task<Firm> GetFirmById(int id)
        {
            var result = await _db.Firms.SingleOrDefaultAsync( m=> m.Id == id);

            if(result != null)
            {
                return result;
            }
            return null;
        }

        public List<GoForCheckOrRedirectDTO> GetProviderActionCheckorRedirect()
        {
             var result = _db.GoForCheckOrRedirects.ToList();

            List<GoForCheckOrRedirectDTO> goForChecksOrRedirectList = new List<GoForCheckOrRedirectDTO>();

            foreach (var item in result)
            {
                EmergencyPropertyDTO emergencyProperty = new EmergencyPropertyDTO();
                EmergencyHelper(item.Id, item.PropertyId, item.PropertyType, out emergencyProperty);

                goForChecksOrRedirectList.Add(new GoForCheckOrRedirectDTO{
                    Id = emergencyProperty.Id,
                    Name = emergencyProperty.Name,
                    FirmName = emergencyProperty.FirmName,
                    Price = emergencyProperty.Price,
                    PropertyLocation = emergencyProperty.PropertyLocation,
                    PropertyType = emergencyProperty.PropertyType,
                    FirmLocation = emergencyProperty.FirmLocation,
                    FirmAction = item.FirmAction.ToString(),
                    PropertyId = item.PropertyId,
                    DateCreated = item.DateCreated.ToShortDateString()
                });


            }

            return goForChecksOrRedirectList;
        }

        public async Task<List<SearchQueryLog>> GetSearchQueryLogs()
        {
            List<SearchQueryLog> refinedLog = new List<SearchQueryLog>();

            var result = await _db.SearchQueryLogs.ToListAsync();

            var searchSorted = result.GroupBy(item => new {item.SearchQuery, item.PropertyType},
            (key,group) => new {
                key1 = key.SearchQuery,
                key2 = key.PropertyType,
                All = group.ToList()
            });

            foreach (var group in searchSorted)
            {
                SearchQueryLog searchLog = new SearchQueryLog();
                searchLog.SearchQuery = group.key1;
                searchLog.PropertyType = group.key2;
                searchLog.CountResultFoundInOtherFirms = 0;
                searchLog.CountResultFoundInQueriedFirm = 0;
                
                foreach (var item in group.All)
                {
                    searchLog.SearchLocation  = item.SearchLocation;
                    searchLog.QueriedFirm = item.QueriedFirm;
                    searchLog.CountResultFoundInQueriedFirm = searchLog.CountResultFoundInQueriedFirm + item.CountResultFoundInQueriedFirm;
                    searchLog.CountResultFoundInOtherFirms = searchLog.CountResultFoundInOtherFirms + item.CountResultFoundInOtherFirms;
                    searchLog.DateQueried =  item.DateQueried;
                }

                refinedLog.Add(searchLog);
            }   

            return refinedLog;     
        }


        public void EmergencyHelper(int id, int propertyId, PropertyType propertyType, out EmergencyPropertyDTO emergencyProperty)
        {
            emergencyProperty = new EmergencyPropertyDTO();
            switch (propertyType)
            {
                case PropertyType.Rental:
                    var property =  _db.RentalProperties.Include(m => m.Firm)
                                                                    .FirstOrDefault(m => m.Id == propertyId);
                    emergencyProperty =  new EmergencyPropertyDTO{
                            Name = property.Name,
                            Price = property.Price,
                            PropertyId = property.Id,
                            PropertyLocation = property.Town + "," + property.City + ","+ property.State,
                            FirmName = property.Firm.Name,
                            FirmLocation = property.Firm.Location,
                            PropertyType = propertyType.ToString(),
                            Id = id
                        };
                    break;

                 case PropertyType.OnSale:
                    var onsale =  _db.OnSaleProperties.Include(m => m.Firm)
                                                                    .FirstOrDefault(m => m.Id == propertyId);
                    emergencyProperty = new EmergencyPropertyDTO{
                            Name = onsale.Name,
                            Price = onsale.Price,
                            PropertyId = onsale.Id,
                            PropertyLocation = onsale.Town + "," + onsale.City + ","+ onsale.State,
                            FirmName = onsale.Firm.Name,
                            FirmLocation = onsale.Firm.Location,
                            PropertyType = propertyType.ToString(),
                            Id = id
                        };
                        break;
                case PropertyType.Commercial:
                    var commercial = _db.CommercialProperties.Include(m => m.Firm)
                                                                    .FirstOrDefault(m => m.Id == propertyId);
                    emergencyProperty = new EmergencyPropertyDTO{
                            Name = commercial.Name,
                            Price = commercial.Price,
                            PropertyId = commercial.Id,
                            PropertyLocation = commercial.Town + "," + commercial.City + ","+ commercial.State,
                            FirmName = commercial.Firm.Name,
                            FirmLocation = commercial.Firm.Location,
                            PropertyType = propertyType.ToString(),
                            Id = id
                        };
                        break;
                case PropertyType.LandProperty:
                    var land = _db.LandProperties.Include(m => m.Firm)
                                                .FirstOrDefault(m => m.Id == propertyId);
                    emergencyProperty =  new EmergencyPropertyDTO{
                            Name = land.Name,
                            Price = land.Price,
                            PropertyId = land.Id,
                            PropertyLocation = land.Town + "," + land.City + ","+ land.State,
                            FirmName = land.Firm.Name,
                            FirmLocation = land.Firm.Location,
                            PropertyType = propertyType.ToString(),
                            Id = id
                        };
                    break;
            }


    }

        public string AdminLogin(string userName, string password)
        {
            if(userName == "hmxworld@admin" && password == "rypt-10902-#red-100")
            {
                return GenerateToken(userName, password);
            }

            return null;
        }


         public string GenerateToken(string userName, string Role)
        {
            //generate token
            var tokenKey = _config.GetSection("AppSettings").GetValue<String>("Token");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { 
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, Role)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}