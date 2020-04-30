using System.Threading.Tasks;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public interface ISubscriptionRepo
    {
        void CreateSubscription(string loginId, Plan plan, string email);
        bool HasItExpired(string loginId);
        bool HasPropertyLimitReached(string loginId);
        void UpgradePlan(string loginId, Plan newPlan);
        void ChangePlan(string loginId, Plan newPlan);

        void RenewSubscription(string loginId);
    }
}