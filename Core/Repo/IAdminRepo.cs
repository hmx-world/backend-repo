using System.Collections.Generic;
using System.Threading.Tasks;
using server.Core.Models;
using tinder4apartment.Models;

namespace server.Core.Repo
{
    public interface IAdminRepo
    {
        public Task<List<FirmDetailsDTO>> GetAllFirms();
        public Task<Firm> GetFirmById(int id);  

        public List<EmergencyPropertyDTO> GetEmergencyProperties();     

        public Task<List<SearchQueryLog>> GetSearchQueryLogs();

        public List<GoForCheckOrRedirectDTO> GetProviderActionCheckorRedirect(); 

        public string AdminLogin(string userName, string Password);

    
    }
}