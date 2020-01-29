using System.Collections.Generic;
using System.Threading.Tasks;
using tinder4apartment.Models;

namespace tinder4apartment.Repo {
    public interface IPropertyManager {
       
       Task<RentalProperty> AddRentalProperty(RentalProperty property);
       Task<OnSaleProperty> AddOnSaleProperty(OnSaleProperty property);

       Task<RentalProperty> GetOneRentalProperty(int id);
       Task<OnSaleProperty> GetOneOnSaleProperty(int id);

        Task<List<RentalProperty>> GetAllRentalProperty ();

        Task<List<OnSaleProperty>> GetAllOnSaleProperty ();

        Task<List<RentalProperty>> GetRentalPropertyByProvider (string providerName);
        Task<List<OnSaleProperty>> GetOnSalePropertyByProvider (string providerName);


   
    }
}