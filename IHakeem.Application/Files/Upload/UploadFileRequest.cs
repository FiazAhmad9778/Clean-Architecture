using MediatR;
using Microsoft.AspNetCore.Http;

namespace iHakeem.Application.Files.Upload
{
    public class UploadFileRequestDTO : IRequest<bool>
    {
        public IFormFile file { get; set; }
    }
}
