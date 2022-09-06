using AutoMapper;
using iHakeem.Application.Lookup.Contracts;
using iHakeem.Domain.Lookups.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Lookup.Create
{
    public class CreateOrUpdateLookupRequestHandler : IRequestHandler<CreateOrUpdateLookupRequestDTO, LookupResponseDTO>
    {
        private readonly ILookupDataRepository _lookupRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrUpdateLookupRequestHandler(ILookupDataRepository lookupRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _lookupRepository = lookupRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<LookupResponseDTO> Handle(CreateOrUpdateLookupRequestDTO request, CancellationToken cancellationToken)
        {
            LookupResponseDTO response = request.Id > 0
                ? _mapper.Map<LookupResponseDTO>(_lookupRepository.Update(_mapper.Map<LookupData>(request), x => x.Value))
                : _mapper.Map<LookupResponseDTO>(await _lookupRepository.Add(_mapper.Map<LookupData>(request)));
            await _unitOfWork.SaveChangesAsync();
            return response;
        }
    }
}
