using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iHakeem.Infrastructure.Security.Abstractions.Authentications.Login
{
    public interface IClaimProvider
    {
        Task<long> GetReferenceIdByRole(long roleId, long userId);
    }
}
