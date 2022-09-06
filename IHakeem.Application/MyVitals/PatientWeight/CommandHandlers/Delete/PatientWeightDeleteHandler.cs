using AutoMapper;
using PatientFamily = iHakeem.Domain.Models.PatientWeight;
using iHakeem.Domain.MyVitals.PatientWeight.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.MyVitals.PatientWeight.CommandHandlers.Delete
{
    public class PatientWeightDeleteHandler : IRequestHandler<PatientWeightDeleteRequestDTO, bool>
    {
        private readonly IPatientWeightRepository _PatientWeightRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientWeightDeleteHandler(IPatientWeightRepository PatientWeightRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _PatientWeightRepository = PatientWeightRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(PatientWeightDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _PatientWeightRepository.GetSingle(x => x.Id == request.Id);
            var user = _mapper.Map<PatientFamily>(res);
            user.IsDeleted = true;
            _PatientWeightRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
