using AutoMapper;
using iHakeem.Application.MedicalDepartments.Contracts;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Departments.IDomainRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.MedicalDepartments.QueryHandlers.BrowseList
{
    public class BrowseMedicalDepartmentHandler
        : IRequestHandler<BrowseMedicalDepartmentFilterDTO, List<MedicalDepartmentResponseDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMedicalDepartmentRepository _medicalDepartmentRepository;

        public BrowseMedicalDepartmentHandler(
            ApplicationDbContext dbContext,
            IMapper mapper,
            IMedicalDepartmentRepository medicalDepartmentRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _medicalDepartmentRepository = medicalDepartmentRepository;
        }

        public async Task<List<MedicalDepartmentResponseDTO>> Handle(BrowseMedicalDepartmentFilterDTO request,
            CancellationToken cancellationToken)
        {
            return await _medicalDepartmentRepository.AllIncluding(x => x.Name, x => x.Description).Select(b =>
             new MedicalDepartmentResponseDTO
             {
                 Id = b.Id,
                 Name = b.Name.Localizations.FirstOrDefault(l => l.CultureCode == "ar").Value,
                 Description = b.Description.Localizations.FirstOrDefault(l => l.CultureCode == "ar").Value,
                 Code = b.Code
             }
            ).ToListAsync();
        }
    }
}

