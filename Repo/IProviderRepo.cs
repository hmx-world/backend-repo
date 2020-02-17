using System.Threading.Tasks;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public interface IProviderRepo
    {
        //register admin
        Task<ProviderLoginDto> CreateProvider (ProviderModel providerDetails);
        Task<ProviderModel> EditProviderInfo(ProviderModel providerDetails, int id);

        Task<string> ProviderLogin(ProviderLoginDto provider);

        Task<ProviderModel> GetProviderDataComplete(int id);

        Task<List<ProviderModel>> GetProviders();
        
    }
}