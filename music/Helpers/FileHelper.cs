using Azure.Storage.Blobs;

namespace music.Helpers
{
    public static class FileHelper
    {
        public static async Task<string> UploadFileAsync(IFormFile file)
        {
            string connection = @"DefaultEndpointsProtocol=https;AccountName=musicaccountstrg;AccountKey=OfepGxiZzY44DW+GI10Y5ctvt8mLOaLtBV2/F+Tva6XT+GFrXu22wEjfIUACWX0e+qEBX36CdCz0+ASt7GbGTA==;EndpointSuffix=core.windows.net";
            string containerName = "songsmt";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connection, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
