using System.Collections.Generic;
using System.Threading.Tasks;
using tinder4apartment.Models;

namespace tinder4apartment.Repo {
    public interface IPropertyManager {
       
       Task<RentalProperty> AddRentalProperty(RentalProperty property);
       Task<OnSaleProperty> AddOnSaleProperty(OnSaleProperty property);

       Task<RentalProperty> GetOneRentalProperty(int id);
       Task<OnSaleProperty> GetOneOnSaleProperty(int id);

        Task<List<RentalProperty>> GetAllActiveRentalProperty ();

        Task<List<OnSaleProperty>> GetAllActiveOnSaleProperty ();

        Task<List<RentalProperty>> GetActiveRentalPropertyByProvider (string providerName);
        Task<List<OnSaleProperty>> GetActiveOnSalePropertyByProvider (string providerName);

        void DeactivateProperty(int id, string mode);


        Task<List<RentalProperty>> GetAllRentalProperty ();

        Task<List<OnSaleProperty>> GetAllOnSaleProperty ();

        Task<List<RentalProperty>> GetRentalPropertyByProvider (string providerName);
        Task<List<OnSaleProperty>> GetOnSalePropertyByProvider (string providerName);



        Task<IndustrialProperty> AddIndustrialProperty(IndustrialProperty property);
        Task<List<IndustrialProperty>> GetIndustrialProperty();
        Task<List<IndustrialProperty>> GetIndustrialPropertyByProvider(string provider);
        Task<IndustrialProperty> GetOneIndustrialProperty (int id);


        Task<List<IndustrialProperty>> GetActiveIndustrialProperty();

        Task<List<IndustrialProperty>> GetActiveIndustrialPropertyByProvider(string provider);
    

   
    }
}