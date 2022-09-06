using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.MyPhysicians.Contracts;
using iHakeem.Database.AppDbContext;
using CurrentMed = iHakeem.Domain.Models.MyPhysicians;
using iHakeem.Domain.EMR.MyPhysicians.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Localization;

namespace iHakeem.Application.EMR.MyPhysicians.QueryHandlers.Detail
{
    public class MyPhysiciansDetailHandler : IRequestHandler<GetMyPhysiciansRequestDTO, MyPhysiciansResponseDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMyPhysiciansRepository _MyPhysiciansRepository;

        public MyPhysiciansDetailHandler(IMyPhysiciansRepository MyPhysiciansRepository, ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _MyPhysiciansRepository = MyPhysiciansRepository;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<MyPhysiciansResponseDTO> Handle(GetMyPhysiciansRequestDTO request, CancellationToken cancellationToken)
        {
            var user = await _MyPhysiciansRepository.GetSingle(request.Id);
            return _mapper.Map<MyPhysiciansResponseDTO>(user);
        }
    }
}
