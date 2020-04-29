using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Paystack.Net.SDK.Customers;
using tinder4apartment.Data;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public class SubscriptionRepo : ISubscriptionRepo
    {
        private readonly PropertyDbContext _db;
        public SubscriptionRepo(PropertyDbContext db)
        {
            _db = db;
        }

        public async void CreateSubscription(string loginId, Plan plan, string email)
        {
            switch (plan)
            {
                case Plan.Business:
                    _db.SubModels.Add(new SubModel{
                        LoginId = loginId,
                        Plan = plan,
                        DueDate = DateTime.Now.AddDays(30).ToString(),
                        PropertyLimit = 20,
                        Email = email
                    });
                    await _db.SaveChangesAsync();
                    break;
                case Plan.Pro:
                    _db.SubModels.Add(new SubModel{
                        LoginId = loginId,
                        Plan = plan,
                        DueDate = DateTime.Now.AddDays(30).ToString(),
                        PropertyLimit = 40,
                        Email = email
                    });
                    break;
                 case Plan.Premium:
                    _db.SubModels.Add(new SubModel{
                        LoginId = loginId,
                        Plan = plan,
                        DueDate = DateTime.Now.AddDays(30).ToString(),
                        PropertyLimit = int.MaxValue,
                        Email = email
                    });
                    break;
                default:
                    break;
            }
        }

        public void DowngradePlan(string loginId, Plan newPlan)
        {
            var subscriptions = _db.SubModels.Where( m=> m.LoginId.Contains(loginId)).AsNoTracking().ToList();
            foreach (var item in subscriptions)
            {
                item.Plan = newPlan;
            }

            _db.SubModels.UpdateRange(subscriptions);
            _db.SaveChanges();
        }

        public bool HasItExpired(string loginId)
        {
            var subscriptionData = _db.SubModels.SingleOrDefault(m => m.LoginId == loginId);
            if(subscriptionData.DueDate == DateTime.Now.ToString())
            {
                return true;
            }
            else{
                return false;
            }
        }

        public bool HasPropertyLimitReached(string loginId)
        {
            var firmData = (from firm in _db.Firms
                            where firm.LoginId.Contains(loginId)
                            select new FirmDetailsDTO{
                                CurrentPlan = firm.Plan.ToString(),
                                RentalProperties = firm.RentalProperties.Count,
                                LandProperties = firm.LandProperties.Count,
                                CommercialProperties = firm.CommercialProperty.Count,
                                OnSaleProperties = firm.OnSaleProperties.Count,
                            }).ToList();
            
            
            
            int limit = _db.SubModels
                    .FirstOrDefault(m => m.LoginId.Contains(loginId)).PropertyLimit;
            

            switch (firmData[0].CurrentPlan)
            {
                case "Premium":
                    return false;
                case "Business":
                    return ComparePropertyInDbandLimit(limit, firmData);
                case "Pro":
                    return ComparePropertyInDbandLimit(limit, firmData);
                default:
                    return ComparePropertyInDbandLimit(limit, firmData);
            }
            
        }

        private bool ComparePropertyInDbandLimit(int limit, List<FirmDetailsDTO> firmData)
        {
            int total = 0;
            foreach (var item in firmData)
            {
                total += item.LandProperties;
                total += item.CommercialProperties;
                total += item.RentalProperties;
                total += item.OnSaleProperties;
            }

            if(total < limit)
            {
                return false;
            }
            else{
                return true;
            }
        }

        public void RenewSubscription(string loginId)
        {
            var subscriptions = _db.SubModels.Where( m=> m.LoginId.Contains(loginId)).AsNoTracking().ToList();
            foreach (var item in subscriptions)
            {
                item.DueDate = DateTime.Now.AddDays(30).ToString();
            }

            _db.SubModels.UpdateRange(subscriptions);
            _db.SaveChanges();
        }

        public void UpgradePlan(string loginId, Plan newPlan)
        {
            var subscriptions = _db.SubModels.Where( m=> m.LoginId.Contains(loginId)).AsNoTracking().ToList();
            foreach (var item in subscriptions)
            {
                item.Plan = newPlan;
            }

            _db.SubModels.UpdateRange(subscriptions);
            _db.SaveChanges();
        }
    }
}