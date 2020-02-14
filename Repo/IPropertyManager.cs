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

       

        void DeactivateProperty(int id, string mode);


        Task<List<RentalProperty>> GetAllRentalProperty ();

        Task<List<OnSaleProperty>> GetAllOnSaleProperty ();

        Task<List<RentalProperty>> GetActiveRentalPropertyByProvider (int providerId);
        Task<List<OnSaleProperty>> GetActiveOnSalePropertyByProvider (int providerId);
        Task<List<RentalProperty>> GetRentalPropertyByProvider (int providerId);
        Task<List<OnSaleProperty>> GetOnSalePropertyByProvider (int providerId);
         Task<List<IndustrialProperty>> GetIndustrialPropertyByProvider(int providerId);
          Task<List<IndustrialProperty>> GetActiveIndustrialPropertyByProvider(int providerId);

        Task<IndustrialProperty> AddIndustrialProperty(IndustrialProperty property);
        Task<List<IndustrialProperty>> GetIndustrialProperty();
       
        Task<IndustrialProperty> GetOneIndustrialProperty (int id);


        Task<List<IndustrialProperty>> GetActiveIndustrialProperty();

       
    
        
   
    }
}