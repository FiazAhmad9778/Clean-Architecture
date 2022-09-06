using iHakeem.Database.AppDbContext;
using iHakeem.Domain.Models;
using iHakeem.Domain.Users.UserVerificationCodes.IDomainRepository;
using iHakeem.Infrastructure.EF.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Infrastructure.EF.Repositories
{
    public class UserVerificationCodeRepository : BaseRepository<UserVerificationCode>, IUserVerificationCodeRepository
    {

        public UserVerificationCodeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }

}
