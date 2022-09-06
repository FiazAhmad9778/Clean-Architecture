using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.PatientMedicalHistory.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class PatientMedicalHistoryRepository : BaseRepository<PatientMedicalHistory>, IPatientMedicalHistoryRepository
    {

        public PatientMedicalHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
