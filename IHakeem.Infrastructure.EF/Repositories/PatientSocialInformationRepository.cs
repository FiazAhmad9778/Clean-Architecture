using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Models;
using iHakeem.Domain.Patients.SocialInfo.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class PatientSocialInformationRepository : BaseRepository<PatientSocialInfo>, IPatientSocialInformationRepository
    {
        public PatientSocialInformationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
