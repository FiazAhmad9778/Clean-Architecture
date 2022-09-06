using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Models;
using iHakeem.Domain.Patients.PatientGaurdians.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class PatientGaurdianRepository : BaseRepository<PatientGaurdian>, IPatientGaurdianRepository
    {
        public PatientGaurdianRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }


    }
}
