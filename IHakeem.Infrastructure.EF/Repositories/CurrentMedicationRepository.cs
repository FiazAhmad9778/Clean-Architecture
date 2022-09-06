using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.CurrentMedication.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class CurrentMedicationRepository : BaseRepository<CurrentMedication>, ICurrentMedicationRepository
    {

        public CurrentMedicationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
