using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

                 var videoFile = property.VideoFIle;

                var videoFileName = videoFile.FileName;
                string videoFileMimeType = videoFile.ContentType;
                byte[] videoFileData = GetBytes(videoFile);

                property.ImageLink3 = _blob.UploadFileToBlob(videoFileName, videoFileData, videoFileMimeType);



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

                 var videoFile = property.VideoFIle;

                var videoFileName = videoFile.FileName;
                string videoFileMimeType = videoFile.ContentType;
                byte[] videoFileData = GetBytes(videoFile);

                property.ImageLink3 = _blob.UploadFileToBlob(videoFileName, videoFileData, videoFileMimeType);
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

        public void DeactivateProperty(int id, string mode)
        {
            switch (mode)
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
                    var industrial = _db.IndustrialProperties.FirstOrDefault(m=> m.Id == id);
                    industrial.IsActive = false;
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

        public async Task<IndustrialProperty> AddIndustrialProperty(IndustrialProperty property)
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

                 var videoFile = property.VideoFIle;

                var videoFileName = videoFile.FileName;
                string videoFileMimeType = videoFile.ContentType;
                byte[] videoFileData = GetBytes(videoFile);

                property.ImageLink3 = _blob.UploadFileToBlob(videoFileName, videoFileData, videoFileMimeType);
                _db.IndustrialProperties.Add(property);
                await _db.SaveChangesAsync();

                return property;
            }

            return null;
        }

        public async Task<List<IndustrialProperty>> GetIndustrialProperty()
        {
            return await _db.IndustrialProperties.ToListAsync();
        }

        public async Task<List<IndustrialProperty>> GetIndustrialPropertyByProvider(int providerId)
        {
            return await _db.IndustrialProperties.Where(m => m.ProviderModelId == providerId).ToListAsync();
        }

        public async Task<IndustrialProperty> GetOneIndustrialProperty(int id)
        {
            return await _db.IndustrialProperties.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<IndustrialProperty>> GetActiveIndustrialProperty()
        {
            return await _db.IndustrialProperties.Where(m => m.IsActive == true).ToListAsync();
        }

        public async Task<List<IndustrialProperty>> GetActiveIndustrialPropertyByProvider(int providerId)
        {
            return await _db.IndustrialProperties.Where(m => m.ProviderModelId == providerId && m.IsActive == true).ToListAsync();
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

    }
}