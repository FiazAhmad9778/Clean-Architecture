using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.MyPhysicians.Contracts;
using CurrentMed = iHakeem.Domain.Models.MyPhysicians;
using iHakeem.Domain.EMR.MyPhysicians.IDomainRepository;
using MediatR;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.MyPhysicians.CommandHandlers.Delete
{
    public class DeleteMyPhysiciansHandler : IRequestHandler<DeleteMyPhysiciansRequestDTO, bool>
    {
        private readonly IMyPhysiciansRepository _MyPhysiciansRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteMyPhysiciansHandler(IMyPhysiciansRepository MyPhysiciansRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _MyPhysiciansRepository = MyPhysiciansRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteMyPhysiciansRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _MyPhysiciansRepository.GetSingle(x => x.Id == request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            user.IsDeleted = true;
            _MyPhysiciansRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
