using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.PatientAllergiesHistory.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class PatientAllergiesHistoryRepository : BaseRepository<PatientAllergiesHistory>, IPatientAllergiesHistoryRepository
    {

        public PatientAllergiesHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
