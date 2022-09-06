using AutoMapper;
using iHakeem.Domain.Files.IDomainRepository;
using iHakeem.Infrastructure.FileStorage;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using iHakeem.Domain.Models;

namespace iHakeem.Application.Files.Upload
{
    public class UploadFileRequestHandler : IRequestHandler<UploadFileRequestDTO, bool>
    {
        private readonly IMapper _mapper;
        private readonly IFileRepository _fileRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IUnitOfWork _unitOfWork;

        public UploadFileRequestHandler(IMapper mapper, IFileRepository fileRepository, IFileStorageService fileStorageService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _fileRepository = fileRepository;
            _fileStorageService = fileStorageService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UploadFileRequestDTO request, CancellationToken cancellationToken)
        {
            var fileRequest = _mapper.Map<UploadFileRequest>(request.file);
            var response = await _fileStorageService.SaveFile(fileRequest);

            var file = _mapper.Map<File>(fileRequest);
            file.Reference = response.Reference;
            file.Type = Convert.ToInt32(response.Storage);
            file.CreatedAt = DateTime.UtcNow;
            await _fileRepository.Add(file);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }
    }
}
