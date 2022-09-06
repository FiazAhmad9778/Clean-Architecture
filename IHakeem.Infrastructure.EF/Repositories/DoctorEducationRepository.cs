using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Doctors.Education;
using iHakeem.Domain.Models;
using iHakeem.Infrastructure.EF.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class DoctorEducationRepository : BaseRepository<DoctorEducation>, IDoctorEducationRepository
    {
        public DoctorEducationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
