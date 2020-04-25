using System.Collections.Generic;
using System.Threading.Tasks;
using server.Core.Models;
using tinder4apartment.Models;

namespace tinder4apartment.Repo {
    public interface IPropertyManager {
       
       Task<RentalProperty> AddRentalProperty(RentalProperty property);
       Task<OnSaleProperty> AddOnSaleProperty(OnSaleProperty property);

       Task<RentalProperty> GetOneRentalProperty(int id);
       Task<OnSaleProperty> GetOneOnSaleProperty(int id);

        Task<List<RentalProperty>> GetAllActiveRentalProperty ();

        Task<List<OnSaleProperty>> GetAllActiveOnSaleProperty ();

       

        void DeactivateProperty(int id, string purpose);


        Task<List<RentalProperty>> GetAllRentalProperty ();

        Task<List<OnSaleProperty>> GetAllOnSaleProperty ();

        Task<List<RentalProperty>> GetActiveRentalPropertyByProvider (int providerId);
        Task<List<OnSaleProperty>> GetActiveOnSalePropertyByProvider (int providerId);
        Task<List<RentalProperty>> GetRentalPropertyByProvider (int providerId);
        Task<List<OnSaleProperty>> GetOnSalePropertyByProvider (int providerId);
         Task<List<CommercialProperty>> GetIndustrialPropertyByProvider(int providerId);
          Task<List<CommercialProperty>> GetActiveIndustrialPropertyByProvider(int providerId);

        Task<CommercialProperty> AddIndustrialProperty(CommercialProperty property);
        Task<List<CommercialProperty>> GetIndustrialProperty();
       
        Task<CommercialProperty> GetOneIndustrialProperty (int id);


        Task<List<CommercialProperty>> GetActiveIndustrialProperty();

       
    
        Task<List<string>> GetProviders();

        Task<Firm> GetOneProvider(int id);

        Task<LandProperty> AddLandProperty(LandProperty property);
        Task<List<LandProperty>> GetAllLandProperties();
        Task<List<LandProperty>> GetAllActiveLandProperties();
        Task<LandProperty> GetOneLandProperty(int id);
         Task<List<LandProperty>> GetAllLandPropertiesByFirm(int id);
        Task<List<LandProperty>> GetAllActiveLandPropertiesByFirm(int id);


        Task<RentalProperty> EditRentalProperty(int id, RentalProperty property);
        Task<OnSaleProperty> EditOnSaleProperty(int id, OnSaleProperty property);
        Task<CommercialProperty> EditCommercialProperty(int id, CommercialProperty property);
        Task<LandProperty> EditLandProperty(int id, LandProperty property);

         void AddProviderAction(GoForCheckOrRedirect checkOrRedirect);
        void AddSearchQueryToLog(string searchQuery, string searchLocation, int queriedFirmId, 
                PropertyType propertyType, int resultInFirm , int resultInOtherFirms);

        void UpdateSearchQueryToLog(string searchQuery, string searchLocation,
                PropertyType propertyType, int resultInFirm , int resultInOtherFirms);

   
    }
}