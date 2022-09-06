using iHakeem.Infrastructure.EF.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using iHakeem.Domain.Files.IDomainRepository;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Models;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class FileRepository : BaseRepository<File>, IFileRepository
    {

        public FileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

    }
}
