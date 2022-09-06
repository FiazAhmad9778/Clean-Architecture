using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.HospitalizationInformation.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class HospitalizationInformationRepository : BaseRepository<HospitalizationInformation>, IHospitalizationInformationRepository
    {

        public HospitalizationInformationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
