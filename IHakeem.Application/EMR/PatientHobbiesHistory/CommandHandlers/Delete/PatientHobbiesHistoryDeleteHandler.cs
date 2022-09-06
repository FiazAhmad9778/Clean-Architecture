using AutoMapper;
using PatientFamily = iHakeem.Domain.Models.PatientHobbiesHistory;
using iHakeem.Domain.EMR.PatientHobbiesHistory.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.EMR.PatientHobbiesHistory.CommandHandlers.Delete
{
    public class PatientHobbiesHistoryDeleteHandler : IRequestHandler<PatientHobbiesHistoryDeleteRequestDTO, bool>
    {
        private readonly IPatientHobbiesHistoryRepository _PatientHobbiesHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientHobbiesHistoryDeleteHandler(IPatientHobbiesHistoryRepository PatientHobbiesHistoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _PatientHobbiesHistoryRepository = PatientHobbiesHistoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(PatientHobbiesHistoryDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _PatientHobbiesHistoryRepository.GetSingle(x => x.Id == request.Id);
            var user = _mapper.Map<PatientFamily>(res);
            user.IsDeleted = true;
            _PatientHobbiesHistoryRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
