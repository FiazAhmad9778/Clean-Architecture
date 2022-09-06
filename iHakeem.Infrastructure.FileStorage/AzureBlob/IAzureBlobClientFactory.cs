using Azure.Storage.Blobs;

namespace iHakeem.Infrastructure.FileStorage.AzureBlob
{
    internal interface IAzureBlobClientFactory
    {
        BlobClient GetBlobClient(string fileReference);
    }
}
