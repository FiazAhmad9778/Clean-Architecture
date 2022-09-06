using iHakeem.Domain.Models;
using iHakeem.SharedKernal.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Domain.Users.IDomainRepository
{
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
    }
}
