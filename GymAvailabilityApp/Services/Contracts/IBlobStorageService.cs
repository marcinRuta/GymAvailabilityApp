namespace GymAvailabilityApp.Services.Contracts
{
    public interface IBlobStorageService
    {
        Task<string> UploadFileToBlobAsync(string strFileName, string contecntType, Stream fileStream, string containerName);
        Task<bool> DeleteFileToBlobAsync(string strFileName, string containerName);
    }
}
