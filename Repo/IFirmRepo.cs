using System.Collections.Generic;
using System.Threading.Tasks;
using server.Core.Models;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public interface IFirmRepo
    {
        //register admin
        Task<List<FirmLoginDto>> CreateFirm (Firm firmDetails);
        Task<Firm> EditFirmInfo(Firm firmDetails, int id);

        Task<FirmVitalInfo> FirmLogin(FirmLoginDto provider);

        Task<Firm> GetFirmDataComplete(int id);

        Task<List<Firm>> GetFirms();

        void AddEmergencyProperty(EmergencyProperty emergencyProperty);

        //go for check or redirect
       
        
    }
}