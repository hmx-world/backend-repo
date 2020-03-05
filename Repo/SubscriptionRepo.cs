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
        public SubModel GetUserDataPlan(string loginId)
        {
            throw new System.NotImplementedException();
        }


        //here pass the subscription model then we go to 
        //paystack to see if the due date is updated or not 
        public bool IsSubscriptionOver(SubModel subModel)
        {
            throw new System.NotImplementedException();
        }

        public void Populate(SubModel subModel)
        {
           _db.Add(subModel);

           _db.SaveChanges();
        }
    }
}