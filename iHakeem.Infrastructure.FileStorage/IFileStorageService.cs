using System.IO;
using System.Threading.Tasks;

namespace iHakeem.Infrastructure.FileStorage
{
    public interface IFileStorageService
    {
        Task<FileReference> SaveFile(UploadFileRequest fileInfo);

        Task<Stream> GetFile(string fileReference);

        Task DeleteFile(string fileReference);
    }
}
