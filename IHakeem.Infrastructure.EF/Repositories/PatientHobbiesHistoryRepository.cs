using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.PatientHobbiesHistory.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class PatientHobbiesHistoryRepository : BaseRepository<PatientHobbiesHistory>, IPatientHobbiesHistoryRepository
    {

        public PatientHobbiesHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
