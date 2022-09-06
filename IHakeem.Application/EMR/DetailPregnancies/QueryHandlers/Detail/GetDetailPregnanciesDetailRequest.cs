using iHakeem.Application.EMR.DetailPregnancies.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.DetailPregnancies.QueryHandlers.Detail
{
    public class GetDetailPregnanciesRequestDTO : IRequest<DetailPregnanciesResponseDTO>
    {
        public long Id { get; set; }
    }
}
