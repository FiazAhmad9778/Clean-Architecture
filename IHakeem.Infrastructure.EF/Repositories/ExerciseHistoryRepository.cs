using System;
using iHakeem.Database.AppDbContext;
using iHakeem.Domain.EMR.ExerciseHistory.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class ExerciseHistoryRepository : BaseRepository<ExerciseHistory>, IExerciseHistoryRepository
    {

        public ExerciseHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
