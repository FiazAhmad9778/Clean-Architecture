namespace iHakeem.Infrastructure.FileStorage
{
    public class FileReference
    {
        public FileReference(FileStorageType storageType, string reference)
        {
            Storage = storageType;
            Reference = reference;
        }

        public FileStorageType Storage { get; }

        public string Reference { get; }
    }
}
