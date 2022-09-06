using AutoMapper;
using iHakeem.Application.Doctors.Contracts;
using iHakeem.Domain.Departments.IDomainRepository;
using iHakeem.Domain.EMR.CurrentMedication.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Doctors.IApplicationService;
using iHakeem.Infrastructure.Security.Abstractions.Authorization.Roles;
using iHakeem.SharedKernal.AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Doctors.CommandHandler.Signup
{
    public class DoctorSignupHandler : IRequestHandler<DoctorSignupRequestDTO, DoctorSignupResponseDTO>
    {
        private readonly IDoctorApplicationService _doctorApplicationService;
        private readonly IMapper _mapper;

        public DoctorSignupHandler(IDoctorApplicationService doctorApplicationService,
            IMapper mapper)
        {
            _doctorApplicationService = doctorApplicationService;
            _mapper = mapper;
        }

        public async Task<DoctorSignupResponseDTO> Handle(DoctorSignupRequestDTO request,
            CancellationToken cancellationToken)
        {
            Doctor Doctor = new Doctor()
            {
                User = _mapper.Map<ApplicationUser>(request)
            };
            Doctor DoctorResponse = await _doctorApplicationService.RegisterDoctor(Doctor, request.Password, Convert.ToInt64(UserRoles.Doctor));
            return _mapper.MergeInto<DoctorSignupResponseDTO>(DoctorResponse.User, DoctorResponse);
        }
    }
}
