using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using GymAvailabilityApp.Services.Contracts;

namespace GymAvailabilityApp.Services
{

    public class BlobStorageService : IBlobStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<BlobStorageService> _logger;
        public BlobStorageService(IConfiguration configuration, ILogger<BlobStorageService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public async Task<string> UploadFileToBlobAsync(string strFileName, string contecntType, Stream fileStream, string containerName)
        {
            try
            {
                var blobContainerClient = new BlobContainerClient(_configuration["BlobStorageConnectionString"], containerName);
                var blobClient = blobContainerClient.GetBlobClient(strFileName);
                await blobClient.UploadAsync(fileStream, overwrite: true );
                return blobClient.Uri.AbsoluteUri;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading file to blob storage");
                throw;
            }
        }
        public async Task<bool> DeleteFileToBlobAsync(string strFileName, string containerName)
        {
            try
            {
                var blobContainerClient = new BlobContainerClient(_configuration["BlobStorageConnectionString"], containerName);
                var blobClient = blobContainerClient.GetBlobClient(strFileName);
                return await blobClient.DeleteIfExistsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting file to blob storage");
                throw;
            }
        }
    }

}
