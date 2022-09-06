using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using iHakeem.Application.EMR.PatientAllergiesHistory.Contracts;
using CurrentMed = iHakeem.Domain.Models.PatientAllergiesHistory;
using iHakeem.Domain.EMR.PatientAllergiesHistory.IDomainRepository;
using MediatR;
using iHakeem.SharedKernal.Domain.IUnitOfWork;

namespace iHakeem.Application.EMR.PatientAllergiesHistory.CommandHandlers.Delete
{
    public class DeletePatientAllergiesHistoryHandler : IRequestHandler<DeletePatientAllergiesHistoryRequestDTO, bool>
    {
        private readonly IPatientAllergiesHistoryRepository _PatientAllergiesHistoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DeletePatientAllergiesHistoryHandler(IPatientAllergiesHistoryRepository PatientAllergiesHistoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _PatientAllergiesHistoryRepository = PatientAllergiesHistoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeletePatientAllergiesHistoryRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _PatientAllergiesHistoryRepository.GetSingle(x => x.Id == request.Id);
            CurrentMed user = _mapper.Map<CurrentMed>(res);
            user.IsDeleted = true;
            _PatientAllergiesHistoryRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
