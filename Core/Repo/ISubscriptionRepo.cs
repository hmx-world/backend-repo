using System.Threading.Tasks;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public interface ISubscriptionRepo
    {
        SubModel Populate(SubModel subModel);

        SubModel GetUserDataPlan(string loginId);


        bool IsSubscriptionOver(string loginId , string id);

        void UpdateUserData(int userSubId, int newPlan);

        Task<bool> IsPropertyLimitOver(int id, SubModel sub);

    }
}