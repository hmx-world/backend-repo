using tinder4apartment.Models;
using System.Threading.Tasks;

namespace tinder4apartment.Repo
{
    public interface IProviderRepo
    {
        ProviderModel AddProvider(ProviderModel provider);
        Task<string> ProviderLogin(ProviderLoginDto providerLogin);

        ProviderModel EditProviderInfo(ProviderModel provider); 

        void RequestRemoval(int providerId);
    }
}