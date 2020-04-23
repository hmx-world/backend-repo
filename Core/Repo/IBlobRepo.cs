using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tinder4apartment.Repo
{
    public interface IBlobRepo
    {
        string UploadFileToBlob(string fileName, byte[] fileData, string fileMimeType);
        void DeleteFileFromBlob(string fileUrl);
    }
}
