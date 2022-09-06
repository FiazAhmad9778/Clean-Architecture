


using iHakeem.Application.EMR.DetailPregnancies.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.DetailPregnancies.QueryHandlers.Detail
{
    public class GetAllDetailPregnanciesDetailRequestDTO : IRequest<List<DetailPregnanciesResponseDTO>>
    {
    }
}
