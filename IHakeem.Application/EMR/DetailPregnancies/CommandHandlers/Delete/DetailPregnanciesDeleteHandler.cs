using AutoMapper;
using PatientFamily = iHakeem.Domain.Models.DetailPregnancies;
using iHakeem.Domain.EMR.DetailPregnancies.IDomainRepository;
using iHakeem.SharedKernal.Domain.IUnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.EMR.DetailPregnancies.CommandHandlers.Delete
{
    public class DetailPregnanciesDeleteHandler : IRequestHandler<DetailPregnanciesDeleteRequestDTO, bool>
    {
        private readonly IDetailPregnanciesRepository _DetailPregnanciesRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DetailPregnanciesDeleteHandler(IDetailPregnanciesRepository DetailPregnanciesRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _DetailPregnanciesRepository = DetailPregnanciesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DetailPregnanciesDeleteRequestDTO request,
            CancellationToken cancellationToken)
        {
            var res = await _DetailPregnanciesRepository.GetSingle(x => x.Id == request.Id);
            var user = _mapper.Map<PatientFamily>(res);
            user.IsDeleted = true;
            _DetailPregnanciesRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
