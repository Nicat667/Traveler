using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class BlobService : IBlobStorage
    {
        private readonly BlobContainerClient _container;
        public BlobService(IConfiguration config)
        {
            var conn = config["AzureBlobStorage:ConnectionString"];
            var containerName = config["AzureBlobStorage:ContainerName"];
            _container = new BlobContainerClient(conn, containerName);
            _container.CreateIfNotExists();
        }
        public Task<bool> DeleteAsync(string blobName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetBlobUrlAsync(string blobName)
        {
            throw new NotImplementedException();
        }

        public Task<string> ReplaceAsync(string oldBlobName, IFormFile newFile)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadAsync(IFormFile file, string fileName = null)
        {
            throw new NotImplementedException();
        }
    }
}
