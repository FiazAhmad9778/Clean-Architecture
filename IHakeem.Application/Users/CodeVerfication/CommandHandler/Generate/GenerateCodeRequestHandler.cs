using AutoMapper;
using iHakeem.Application.Patients.Contracts;
using iHakeem.Domain.Departments.IDomainRepository;
using iHakeem.Domain.EMR.CurrentMedication.IDomainRepository;
using iHakeem.Domain.Models;
using iHakeem.Domain.Patients.IApplicationService;
using iHakeem.Domain.Patients.IDomainRepository;
using iHakeem.Domain.Users.UserVerificationCodes.IDomainService;
using iHakeem.Infrastructure.Security.Abstractions.Authorization.Roles;
using iHakeem.SharedKernal.AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Application.Users.CodeVerfication.CommandHandler.Generate
{
    public class GenerateCodeRequestHandler : IRequestHandler<GenerateCodeRequestDTO, Unit>
    {
        private readonly IUserVerficationCodeService _userVerficationCodeService;

        public GenerateCodeRequestHandler(IUserVerficationCodeService userVerficationCodeService)
        {
            _userVerficationCodeService = userVerficationCodeService;
        }

        public async Task<Unit> Handle(GenerateCodeRequestDTO request,
            CancellationToken cancellationToken)
        {

            await _userVerficationCodeService.regenerateCode(request.UserId);
            return Unit.Value;
        }
    }
}
