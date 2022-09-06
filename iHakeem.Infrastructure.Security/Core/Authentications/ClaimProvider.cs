using iHakeem.Domain.Doctors.IDomainRepository;
using iHakeem.Domain.Patients.IDomainRepository;
using iHakeem.Infrastructure.Common.Exceptions;
using iHakeem.Infrastructure.Security.Abstractions.Authentications.Login;
using iHakeem.Infrastructure.Security.Abstractions.Authorization.Roles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iHakeem.Infrastructure.Security.Core.Authentications
{
    public class ClaimProvider : IClaimProvider
    {
        private readonly IPatientRepository _pateintRepository;
        private readonly IDoctorRepository _doctorRepository;

        public ClaimProvider(IPatientRepository pateintRepository, IDoctorRepository doctorRepository)
        {
            _pateintRepository = pateintRepository;
            _doctorRepository = doctorRepository;
        }
        public async Task<long> GetReferenceIdByRole(long roleId, long userId)
        {
            if (roleId == Convert.ToInt64(UserRoles.Patient))
            {
                var patient = await _pateintRepository.GetSingle(x => x.UserId == userId);
                return patient.Id;
            }
            if (roleId == Convert.ToInt64(UserRoles.Doctor))
            {
                var doctor = await _doctorRepository.GetSingle(x => x.UserId == userId);
                return doctor.Id;
            }
            throw new CodedException(ErrorCode.Unauthenticated);
        }
    }
}
