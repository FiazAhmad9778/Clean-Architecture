using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Models;
using iHakeem.Domain.Patients.PatientSocialInfo.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class PatientEmergencyContactRepository : BaseRepository<PatientEmergencyContact>, IPatientEmergencyContactRepository
    {
        public PatientEmergencyContactRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
