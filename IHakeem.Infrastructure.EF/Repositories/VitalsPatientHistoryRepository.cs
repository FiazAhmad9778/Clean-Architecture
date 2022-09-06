using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.VitalsPatientHistory.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class VitalsPatientHistoryRepository : BaseRepository<GetAllPatientVitalsHistory>, IVitalsPatientHistoryRepository
    {

        public VitalsPatientHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
