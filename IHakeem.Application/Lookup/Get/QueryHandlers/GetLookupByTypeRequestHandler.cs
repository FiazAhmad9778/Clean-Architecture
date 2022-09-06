using AutoMapper;
using iHakeem.Application.Lookup.Contracts;
using iHakeem.Domain.Lookups.IDomainRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Lookup.QueryHandlers
{
    public class GetLookupByTypeRequestHandler : IRequestHandler<GetLookupByTypeRequestDTO, List<LookupResponseDTO>>
    {
        private readonly ILookupRepository _lookupRepository;
        private readonly IMapper _mapper;

        public GetLookupByTypeRequestHandler(ILookupRepository lookupRepository, IMapper mapper)
        {
            _lookupRepository = lookupRepository;
            _mapper = mapper;
        }
        public async Task<List<LookupResponseDTO>> Handle(GetLookupByTypeRequestDTO request, CancellationToken cancellationToken)
        {
            var lookUpData = await _lookupRepository.GetSingle(x => x.Name.Trim().Equals(request.LookupName), x => x.LookupData);

            return _mapper.Map<List<LookupResponseDTO>>(lookUpData.LookupData);
        }
    }
}
