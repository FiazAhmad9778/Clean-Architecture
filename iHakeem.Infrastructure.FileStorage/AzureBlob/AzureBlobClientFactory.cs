using Azure.Storage.Blobs;

namespace iHakeem.Infrastructure.FileStorage.AzureBlob
{
    internal class AzureBlobClientFactory : IAzureBlobClientFactory
    {

        public AzureBlobClientFactory()
        {
        }

        public BlobClient GetBlobClient(string fileReference)
        {
            BlobContainerClient rootContainerClient = GetRootContainerClient();
            var container = rootContainerClient.CreateIfNotExists();
            return rootContainerClient.GetBlobClient(fileReference);
        }

        private BlobContainerClient GetRootContainerClient()
        {
            var serviceClient = new BlobServiceClient(AzureBlobStorageOptions.ConnectionString);
            return serviceClient.GetBlobContainerClient(AzureBlobStorageOptions.RootContainer);
        }
    }
}
