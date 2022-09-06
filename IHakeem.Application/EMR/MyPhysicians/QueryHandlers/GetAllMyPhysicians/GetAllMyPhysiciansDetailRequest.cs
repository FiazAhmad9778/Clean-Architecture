


using iHakeem.Application.EMR.MyPhysicians.Contracts;
using MediatR;
using System.Collections.Generic;

namespace iHakeem.Application.EMR.MyPhysicians.QueryHandlers.Detail
{
    public class GetAllMyPhysiciansDetailRequestDTO : IRequest<List<MyPhysiciansResponseDTO>>
    {
    }
}
