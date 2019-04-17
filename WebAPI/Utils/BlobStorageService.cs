using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Utils
{
    public class BlobStorageService
    {
        private IConfiguration _configuration;

        public BlobStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreateBlob(string fileName, string contentType, byte[] data)
        {
            CloudStorageAccount storageAccount;
            CloudBlobClient client;
            CloudBlobContainer container;
            CloudBlockBlob blob;

            storageAccount = CloudStorageAccount.Parse(_configuration["BlobConnectionString"]);

            client = storageAccount.CreateCloudBlobClient();

            container = client.GetContainerReference("pergunteme");

            var timenow = DateTime.Now.ToString("dd-MM-yyyy HH-mm");

            blob = container.GetBlockBlobReference(timenow + " - " + fileName);
            blob.Properties.ContentType = contentType;

            await blob.UploadFromByteArrayAsync(data, 0, data.Length);

            return blob.StorageUri.PrimaryUri.ToString();
        }
    }
}
