using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public interface ISubscriptionRepo
    {
        void Populate(SubModel subModel);

        SubModel GetUserDataPlan(string loginId);


        bool IsSubscriptionOver(SubModel subModel);
    }
}