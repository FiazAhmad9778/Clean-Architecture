using System.Collections.Generic;
using iHakeem.Application.MedicalDepartments.Contracts;
using MediatR;

namespace iHakeem.Application.MedicalDepartments.QueryHandlers.BrowseList
{
    public class BrowseMedicalDepartmentFilterDTO : IRequest<List<MedicalDepartmentResponseDTO>>
    {
        //add any required filteration like start/end Date , searching keyword, ...etc.

        public string SearchingWord { get; set; }

    }
}
