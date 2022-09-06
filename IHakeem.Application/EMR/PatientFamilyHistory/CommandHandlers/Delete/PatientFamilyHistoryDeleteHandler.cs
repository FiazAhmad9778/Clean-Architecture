using AutoMapper;
using PatientFamily = iHakeem.Domain.Models.PatientFamilyHistory;
using iHakeem.Domain.EMR.PatientFamilyHistory.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.EMR.PatientFamilyHistory.CommandHandlers.Delete
{
    public class PatientFamilyHistoryDeleteHandler : IRequestHandler<PatientFamilyHistoryDeleteRequestDTO, bool>
    {
        private readonly IPatientFamilyHistoryRepository _PatientFamilyHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientFamilyHistoryDeleteHandler(IPatientFamilyHistoryRepository PatientFamilyHistoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _PatientFamilyHistoryRepository = PatientFamilyHistoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(PatientFamilyHistoryDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _PatientFamilyHistoryRepository.GetSingle(x => x.Id == request.Id);
            var user = _mapper.Map<PatientFamily>(res);
            user.IsDeleted = true;
            _PatientFamilyHistoryRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
