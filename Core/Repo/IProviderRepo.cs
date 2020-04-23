using System.Collections.Generic;
using System.Threading.Tasks;
using server.Core.Models;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public interface IProviderRepo
    {
        //register admin
        Task<ProviderLoginDto> CreateProvider (ProviderModel providerDetails);
        Task<ProviderModel> EditProviderInfo(ProviderModel providerDetails, int id);

        Task<ProviderVitalInfo> ProviderLogin(ProviderLoginDto provider);

        Task<ProviderModel> GetProviderDataComplete(int id);

        Task<List<ProviderModel>> GetProviders();

        void AddEmergencyProperty(EmergencyProperty emergencyProperty);

        //go for check or redirect
       
        
    }
}