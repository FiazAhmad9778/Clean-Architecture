using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.PharmacyInformation.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class PharmacyInformationRepository : BaseRepository<PharmacyInformation>, IPharmacyInformationRepository
    {

        public PharmacyInformationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
