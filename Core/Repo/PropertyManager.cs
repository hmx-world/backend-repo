using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using server.Core.Models;
using tinder4apartment.Data;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public class PropertyManager : IPropertyManager
    {
        private readonly PropertyDbContext _db;
        private IBlobRepo _blob;
        public PropertyManager(PropertyDbContext db, IBlobRepo blob)
        {
            _db = db;
            _blob = blob;
        }

        public async Task<OnSaleProperty> AddOnSaleProperty(OnSaleProperty property)
        {
            if (property != null)
            {
                property.IsActive = true;
                
                var image = property.imageFile1;

                var imageFileName = image.FileName;
                string imageMimeType = image.ContentType;
                byte[] imageData = GetBytes(property.imageFile1);

                property.ImageLink1 = _blob.UploadFileToBlob(imageFileName, imageData, imageMimeType);

                var image1 = property.imageFile2;

                var imageFileName2 = image1.FileName;
                string imageMimeType2 = image1.ContentType;
                byte[] imageData2 = GetBytes(image1);

                property.ImageLink2 = _blob.UploadFileToBlob(imageFileName2, imageData2, imageMimeType2);

                var image2 = property.imageFile3;

                var imageFileName3 = image2.FileName;
                string imageMimeType3 = image2.ContentType;
                byte[] imageData3 = GetBytes(image2);

                property.ImageLink3 = _blob.UploadFileToBlob(imageFileName3, imageData3, imageMimeType3);

                 var videoFile = property.imageFile4;

                var videoFileName = videoFile.FileName;
                string videoFileMimeType = videoFile.ContentType;
                byte[] videoFileData = GetBytes(videoFile);

                property.ImageLink4 = _blob.UploadFileToBlob(videoFileName, videoFileData, videoFileMimeType);



                _db.OnSaleProperties.Add(property);
                await _db.SaveChangesAsync();

                return property;
            }

            return null;
        }

        public async Task<RentalProperty> AddRentalProperty(RentalProperty property)
        {
             if (property != null)
            {
                 property.IsActive = true;
                
                var image = property.imageFile1;

                var imageFileName = image.FileName;
                string imageMimeType = image.ContentType;
                byte[] imageData = GetBytes(property.imageFile1);

                property.ImageLink1 = _blob.UploadFileToBlob(imageFileName, imageData, imageMimeType);

                var image1 = property.imageFile2;

                var imageFileName2 = image1.FileName;
                string imageMimeType2 = image1.ContentType;
                byte[] imageData2 = GetBytes(image1);

                property.ImageLink2 = _blob.UploadFileToBlob(imageFileName2, imageData2, imageMimeType2);

                var image2 = property.imageFile3;

                var imageFileName3 = image2.FileName;
                string imageMimeType3 = image2.ContentType;
                byte[] imageData3 = GetBytes(image2);

                property.ImageLink3 = _blob.UploadFileToBlob(imageFileName3, imageData3, imageMimeType3);

                 var videoFile = property.imageFile4;

                var videoFileName = videoFile.FileName;
                string videoFileMimeType = videoFile.ContentType;
                byte[] videoFileData = GetBytes(videoFile);

                property.ImageLink4 = _blob.UploadFileToBlob(videoFileName, videoFileData, videoFileMimeType);
                _db.RentalProperties.Add(property);
                await _db.SaveChangesAsync();

                return property;
            }

            return null;
        }

        public async Task<OnSaleProperty> GetOneOnSaleProperty(int id)
        {
            return await _db.OnSaleProperties.FirstOrDefaultAsync(m=> m.Id == id);
        }

        public async Task<RentalProperty> GetOneRentalProperty(int id)
        {
            return await _db.RentalProperties.FirstOrDefaultAsync(m=> m.Id == id);
        }

        public async Task<List<OnSaleProperty>> GetAllActiveOnSaleProperty()
        {
            return await _db.OnSaleProperties.Where(m => m.IsActive == true).ToListAsync();
        }

        public async Task<List<OnSaleProperty>> GetActiveOnSalePropertyByProvider(int providerId)
        {
            return await _db.OnSaleProperties.Where(m => m.ProviderModelId == providerId && m.IsActive == true).ToListAsync();
        }

        public async Task<List<RentalProperty>> GetAllActiveRentalProperty()
        {
            return await _db.RentalProperties.Where(m => m.IsActive == true).ToListAsync();
        }

        public async Task<List<RentalProperty>> GetActiveRentalPropertyByProvider(int providerId)
        {
            return await _db.RentalProperties.Where(m => m.ProviderModelId == providerId && m.IsActive == true ).ToListAsync();
        }

        public void DeactivateProperty(int id, string purpose)
        {
            switch (purpose)
            {
                case "rental":
                    var rental =  _db.RentalProperties.FirstOrDefault(m => m.Id == id);
                    rental.IsActive = false;
                    _db.SaveChanges();
                    break;
                
                case "onsale":
                    var onsale = _db.OnSaleProperties.FirstOrDefault(m=> m.Id == id);
                    onsale.IsActive = false;
                    _db.SaveChanges();
                    break;
                
                case "industrial":
                    var industrial = _db.CommercialProperties.FirstOrDefault(m=> m.Id == id);
                    industrial.IsActive = false;
                    _db.SaveChanges();
                    break;
                
                case "landproperty":
                    var landproperty = _db.LandProperties.FirstOrDefault(m=> m.Id == id);
                    landproperty.IsActive = false;
                    _db.SaveChanges();
                    break;
                default:
                    break;
            }
        }

        public async Task<List<RentalProperty>> GetAllRentalProperty()
        {
            return await _db.RentalProperties.ToListAsync();
        }

        public async Task<List<OnSaleProperty>> GetAllOnSaleProperty()
        {
            return await _db.OnSaleProperties.ToListAsync();
        }

        public async Task<List<RentalProperty>> GetRentalPropertyByProvider(int providerId)
        {
            return await _db.RentalProperties.Where(m => m.ProviderModelId== providerId).ToListAsync();
        }

        public async Task<List<OnSaleProperty>> GetOnSalePropertyByProvider(int providerId)
        {
            return await _db.OnSaleProperties.Where(m => m.ProviderModelId == providerId).ToListAsync();
        }

        public async Task<CommercialProperty> AddIndustrialProperty(CommercialProperty property)
        {
             if (property != null)
            {
                 property.IsActive = true;
                
                var image = property.imageFile1;

                var imageFileName = image.FileName;
                string imageMimeType = image.ContentType;
                byte[] imageData = GetBytes(property.imageFile1);

                property.ImageLink1 = _blob.UploadFileToBlob(imageFileName, imageData, imageMimeType);

                var image1 = property.imageFile2;

                var imageFileName2 = image1.FileName;
                string imageMimeType2 = image1.ContentType;
                byte[] imageData2 = GetBytes(image1);

                property.ImageLink2 = _blob.UploadFileToBlob(imageFileName2, imageData2, imageMimeType2);

                var image2 = property.imageFile3;

                var imageFileName3 = image2.FileName;
                string imageMimeType3 = image2.ContentType;
                byte[] imageData3 = GetBytes(image2);

                property.ImageLink3 = _blob.UploadFileToBlob(imageFileName3, imageData3, imageMimeType3);

                 var videoFile = property.imageFile4;

                var videoFileName = videoFile.FileName;
                string videoFileMimeType = videoFile.ContentType;
                byte[] videoFileData = GetBytes(videoFile);

                property.ImageLink4 = _blob.UploadFileToBlob(videoFileName, videoFileData, videoFileMimeType);
                _db.CommercialProperties.Add(property);
                await _db.SaveChangesAsync();

                return property;
            }

            return null;
        }

        public async Task<List<CommercialProperty>> GetIndustrialProperty()
        {
            return await _db.CommercialProperties.ToListAsync();
        }

        public async Task<List<CommercialProperty>> GetIndustrialPropertyByProvider(int providerId)
        {
            return await _db.CommercialProperties.Where(m => m.ProviderModelId == providerId).ToListAsync();
        }

        public async Task<CommercialProperty> GetOneIndustrialProperty(int id)
        {
            return await _db.CommercialProperties.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<CommercialProperty>> GetActiveIndustrialProperty()
        {
            return await _db.CommercialProperties.Where(m => m.IsActive == true).ToListAsync();
        }

        public async Task<List<CommercialProperty>> GetActiveIndustrialPropertyByProvider(int providerId)
        {
            return await _db.CommercialProperties.Where(m => m.ProviderModelId == providerId && m.IsActive == true).ToListAsync();
        }

        public async Task<List<string>> GetProviders()
        {
            return await _db.ProviderModels.Select(m => m.Name).ToListAsync();
        }

        public static byte[] GetBytes(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public async Task<ProviderModel> GetOneProvider(int id)
        {
            var provider =  await _db.ProviderModels.FirstOrDefaultAsync(m=> m.Id == id);

            provider.Password = null;
            provider.PasswordHash = null;
            provider.PasswordSalt = null;

            return provider;
        }

        public async Task<LandProperty> AddLandProperty(LandProperty property)
        {
             if (property != null)
            {
                 property.IsActive = true;
                
                var image = property.imageFile1;

                var imageFileName = image.FileName;
                string imageMimeType = image.ContentType;
                byte[] imageData = GetBytes(property.imageFile1);

                property.ImageLink1 = _blob.UploadFileToBlob(imageFileName, imageData, imageMimeType);

                var image1 = property.imageFile2;

                var imageFileName2 = image1.FileName;
                string imageMimeType2 = image1.ContentType;
                byte[] imageData2 = GetBytes(image1);

                property.ImageLink2 = _blob.UploadFileToBlob(imageFileName2, imageData2, imageMimeType2);

                var image2 = property.imageFile3;

                var imageFileName3 = image2.FileName;
                string imageMimeType3 = image2.ContentType;
                byte[] imageData3 = GetBytes(image2);

                property.ImageLink3 = _blob.UploadFileToBlob(imageFileName3, imageData3, imageMimeType3);

                
                _db.LandProperties.Add(property);
                await _db.SaveChangesAsync();

                return property;
            }

            return null;
        }

        public async Task<List<LandProperty>> GetAllLandProperties()
        {
            return await _db.LandProperties.ToListAsync();
        }

        public async Task<List<LandProperty>> GetAllActiveLandProperties()
        {
            return await _db.LandProperties.Where(m=> m.IsActive == true).ToListAsync();
        }

        public async Task<LandProperty> GetOneLandProperty(int id)
        {
            return await _db.LandProperties.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<LandProperty>> GetAllLandPropertiesByFirm(int id)
        {
            return await _db.LandProperties.Where(m =>m.Id == id).ToListAsync();
        }

        public async Task<List<LandProperty>> GetAllActiveLandPropertiesByFirm(int id)
        {
            return await _db.LandProperties.Where(m=> m.IsActive == true && m.ProviderModelId == id).ToListAsync(); 
        }

        public async Task<RentalProperty> EditRentalProperty(int id, RentalProperty property)
        {
            RentalProperty rental = null;

            rental = _db.RentalProperties.AsNoTracking().FirstOrDefault(m => m.Id == id);
            rental = property;
            rental.Id  = id;

            _db.RentalProperties.Update(rental);
            await _db.SaveChangesAsync();

            return rental;

            
        }

        public async Task<OnSaleProperty> EditOnSaleProperty(int id, OnSaleProperty property)
        {
            OnSaleProperty onSale = null;

            onSale = _db.OnSaleProperties.AsNoTracking().FirstOrDefault(m => m.Id == id);
            onSale = property;
            onSale.Id  = id;

            _db.OnSaleProperties.Update(onSale);
            await _db.SaveChangesAsync();

            return onSale;

        }

        public async Task<CommercialProperty> EditCommercialProperty(int id, CommercialProperty property)
        {
             CommercialProperty commercialProperty = null;

            commercialProperty = _db.CommercialProperties.AsNoTracking().FirstOrDefault(m => m.Id == id);
            commercialProperty = property;
            commercialProperty.Id  = id;

            _db.CommercialProperties.Update(commercialProperty);
            await _db.SaveChangesAsync();

            return commercialProperty;
        }

        public async Task<LandProperty> EditLandProperty(int id, LandProperty property)
        {
            LandProperty landProperty = null;

            landProperty = _db.LandProperties.AsNoTracking().FirstOrDefault(m => m.Id == id);
            landProperty = property;
            landProperty.Id  = id;

            _db.LandProperties.Update(landProperty);
            await _db.SaveChangesAsync();

            return landProperty;
        }

        public void AddProviderAction(GoForCheckOrRedirect checkOrRedirect)
        {
            _db.GoForCheckOrRedirects.Add(checkOrRedirect);
            _db.SaveChangesAsync();
        }

       
        public async void AddSearchQueryToLog(string searchQuery, string searchLocation, int queriedFirmId, PropertyType propertyType, int resultInFirm, int resultInOtherFirms)
        {
             var firm = await _db.ProviderModels.FirstOrDefaultAsync(m => m.Id == queriedFirmId);
            var searchLog = new SearchQueryLog{
                SearchQuery = searchQuery,
                SearchLocation = searchLocation,
                QueriedFirm = firm.Name,
                PropertyType = propertyType,
                CountResultFoundInQueriedFirm = resultInFirm,
                CountResultFoundInOtherFirms = resultInOtherFirms, 
                DateQueried = DateTime.Now
            };

            SaveSearchQueryToDb(searchLog);
        }

         public void SaveSearchQueryToDb(SearchQueryLog searchQueryLog)
        {
            _db.SearchQueryLogs.Add(searchQueryLog);
            _db.SaveChangesAsync();
        }

        public async void UpdateSearchQueryToLog(string searchQuery, string searchLocation, 
            PropertyType propertyType, int resultInFirm, int resultInOtherFirms)
        {
            var searchResult = await _db.SearchQueryLogs.AsNoTracking().FirstOrDefaultAsync(m => m.SearchQuery == searchQuery);
            searchResult.CountResultFoundInOtherFirms = resultInOtherFirms;
            _db.SearchQueryLogs.Update(searchResult);
            await _db.SaveChangesAsync();
        }
    }
}