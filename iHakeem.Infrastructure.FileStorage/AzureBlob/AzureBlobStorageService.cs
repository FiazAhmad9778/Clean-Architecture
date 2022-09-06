using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using iHakeem.Infrastructure.FileStorage.FileSystem;
using System;
using System.IO;
using System.Threading.Tasks;

namespace iHakeem.Infrastructure.FileStorage.AzureBlob
{
    internal class AzureBlobStorageService : IFileStorageService
    {
        private readonly IAzureBlobClientFactory _azureBlobClientFactory;

        public AzureBlobStorageService(IAzureBlobClientFactory azureBlobClientFactory)
        {
            _azureBlobClientFactory = azureBlobClientFactory;
        }

        public async Task<FileReference> SaveFile(UploadFileRequest fileInfo)
        {
            string fileReference = Guid.NewGuid().ToString();
            BlobClient blobClient = _azureBlobClientFactory.GetBlobClient(fileReference);

            Stream fileStream = fileInfo.GetStream;
            await blobClient.UploadAsync(
                fileStream,
                new BlobHttpHeaders
                {
                    ContentType = fileInfo.ContentType,
                });

            return new FileReference(FileStorageType.AzureBlob, fileReference);
        }

        public async Task<Stream> GetFile(string fileReference)
        {
            BlobClient blobClient = _azureBlobClientFactory.GetBlobClient(fileReference);

            var tempFileStream = new TempFileStream();
            await blobClient.DownloadToAsync(tempFileStream);
            tempFileStream.Seek(0, SeekOrigin.Begin);

            return tempFileStream;
        }

        public async Task DeleteFile(string fileReference)
        {
            BlobClient blobClient = _azureBlobClientFactory.GetBlobClient(fileReference);

            await blobClient.DeleteAsync();
        }
    }
}
