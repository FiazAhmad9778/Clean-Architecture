using iHakeem.SharedKernal.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using iHakeem.Domain.Models;

namespace iHakeem.Domain.Users.UserVerificationCodes.IDomainRepository
{
    public interface IUserVerificationCodeRepository : IBaseRepository<UserVerificationCode>
    {
    }
}
