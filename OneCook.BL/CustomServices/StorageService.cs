using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OneCook.BL.CustomServices.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OneCook.BL.CustomServices
{
    public class StorageService : IStorageService
    {
        private BlobContainerClient blobContainerClient;


        public StorageService()
        {
            blobContainerClient = new BlobContainerClient("");
        }
        public async Task UploadFile(string name, IFormFile file)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    ms.Position = 0;
                    string imageName = CheckExtension(name, file.ContentType);
                    await blobContainerClient.UploadBlobAsync(name, ms);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private string CheckExtension(string name, string contentType)
        {

            switch (contentType)
            {
                case "image/png":
                    return name + ".png";
                case "image/jpg":
                    return name + ".jpg";
                case "image/jpeg":
                    return name + ".jpg";
                default:
                    throw new Exception("Internal server error");


            }
        }

    }
}
