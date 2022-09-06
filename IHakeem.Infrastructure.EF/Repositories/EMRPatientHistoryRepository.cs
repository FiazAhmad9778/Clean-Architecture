using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.EMRPatientHistory.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class EMRPatientHistoryRepository : BaseRepository<GetAllPatientHistory>, IEMRPatientHistoryRepository
    {

        public EMRPatientHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
