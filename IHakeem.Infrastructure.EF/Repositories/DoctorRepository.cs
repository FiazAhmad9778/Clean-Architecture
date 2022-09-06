using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Models;
using iHakeem.Domain.Doctors.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {

        public DoctorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
