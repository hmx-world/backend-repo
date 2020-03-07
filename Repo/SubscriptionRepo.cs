using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Paystack.Net.SDK.Customers;
using tinder4apartment.Data;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public class SubscriptionRepo : ISubscriptionRepo
    {
        private readonly PropertyDbContext _db;
        private readonly IConfiguration _config; 
        string _paystackKey = string.Empty;

        private readonly IProviderRepo _provider;
        
        public SubscriptionRepo(PropertyDbContext db, IConfiguration config, IProviderRepo provider)
        {
            _db = db;
            _config = config;
            _paystackKey = _config.GetConnectionString("Test_Skey");
            _provider = provider;
        }
        public SubModel GetUserDataPlan(string loginId)
        {
            var result = _db.SubModels.FirstOrDefault(m=> m.LoginId == loginId);

            return result; 
        }

        public async Task<bool> IsPropertyLimitOver(int id, SubModel sub)
        {
            ProviderModel provider = await _provider.GetProviderDataComplete(id);

            int industrial = provider.IndustrialProperty.Count();
            int rental = provider.RentalProperties.Count();
            int onsale = provider.OnSaleProperties.Count();


            if (sub.PropertyLimit == (industrial + rental + onsale))
            {
                return true;
            }
            else if ((industrial + rental + onsale) > sub.PropertyLimit){
                return true;
            }
                 return false;
        }


        //here pass the subscription model then we go to 
        //paystack to see if the due date is updated or not 
        public bool IsSubscriptionOver(string loginId, string duedate)
        {
           var result = GetUserDataPlan(loginId);

            String[] splits = duedate.Split('T');

            string dueDatePayStack = splits[0];
            string dueDateDB = result.DueDate;

            if(dueDateDB.ToLower() == dueDatePayStack.ToLower()){
                return true;
            }
            else if(dueDateDB.ToLower() != dueDatePayStack.ToLower()){
                
                //update the data on table 
                var sub = _db.SubModels.First(m=> m.Id == result.Id);
                if(sub.Plan == Plan.Basic){
                    sub.PropertyLimit = sub.PropertyLimit + 20;
                }
                else if(sub.Plan == Plan.Premium){
                    sub.PropertyLimit = sub.PropertyLimit + 30;
                }
                sub.DueDate = dueDatePayStack;
                _db.SaveChanges();
                
                return false;
            }

            return true;      
        }

        public SubModel Populate(SubModel subModel)
        {
            string dateNow =DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            subModel.DueDate = dateNow;
            switch (subModel.Plan)
            {
                case Plan.Basic:
                    subModel.PropertyLimit = 20;
                    break;
                case Plan.Trial:
                    subModel.PropertyLimit = 10;
                    break;
                case Plan.Premium:
                    subModel.PropertyLimit = 30;
                    break;
                default:
                    subModel.PropertyLimit = 10;
                    break;
            }

           _db.Add(subModel);

           _db.SaveChanges();

           return subModel;
        }

        public void UpdateUserData(int userSubId, int newPlan)
        {
            var sub = _db.SubModels.FirstOrDefault(m => m.Id == userSubId);
            sub.Plan =  (Plan)newPlan;
            sub.DueDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            sub.PropertyLimit = PropertyLimitBasedOnNewPlan(sub.PropertyLimit, newPlan);

            _db.SaveChanges();

        }

        private int PropertyLimitBasedOnNewPlan(int currentPropertyLimit, int newPlan)
        {
            if(newPlan == 1){
                return currentPropertyLimit+20;
            }
            else if(newPlan == 2){
                return currentPropertyLimit + 30;
            }

            return 0;
        }

       
    }
}