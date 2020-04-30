using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace tinder4apartment.Repo
{
    public class BlobRepo : IBlobRepo
    {
       // private readonly IConfiguration _configuration;
        string _accessKey = "DefaultEndpointsProtocol=https;AccountName=propertyb2bstorage;AccountKey=VGSs+KadJLDZTBt8uHfzPAYXeoew3CVdHUs9Ftons+7ds7kYt5s9xE9u9j+e8/HkcSZeuhtWU5hr6OasueH8RQ==;EndpointSuffix=core.windows.net";
   
        public void DeleteFileFromBlob(string fileUrl)
        {
            throw new NotImplementedException();
        }

        public string UploadFileToBlob(string fileName, byte[] fileData, string fileMimeType)
        {
            try
            {
                var task = Task.Run(() => this.UploadFileToBlobAsync(fileName, fileData, fileMimeType));
                task.Wait();
                string fileUrl = task.Result;
                return fileUrl;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }

        private async Task<string> UploadFileToBlobAsync(string fileName, byte[] fileData, string fileMimeType)
        {
            try
            {
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(_accessKey);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                string containerName = "tinder4apartmentuploads";
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
                string generatedFileName = this.GenerateFileName(fileName);

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                }

                if (generatedFileName != null && fileData != null)
                {
                    CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(generatedFileName);
                    cloudBlockBlob.Properties.ContentType = fileMimeType;
                    await cloudBlockBlob.UploadFromByteArrayAsync(fileData, 0, fileData.Length);

                    return cloudBlockBlob.Uri.ToString();
                }

                return "";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string GenerateFileName(string fileName)
        {
            string strFileName = string.Empty;
            string[] strName = fileName.Split('.');
            strFileName = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd") + "/" + DateTime.Now.ToUniversalTime().ToString("yyyMMdd\\THHmmssfff") + "." + strName[strName.Length - 1];
            return strFileName;
        }
    }
}