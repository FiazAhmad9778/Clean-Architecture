using iHakeem.Application.Patients.CommandHandler.Signup;
using iHakeem.Application.Patients.EmergencyContact.CommadHandler.Create;
using iHakeem.Application.Patients.EmergencyContact.QueryHandler.List;
using iHakeem.Application.Patients.PatientEmergencyContacts.CommandHandlers.Delete;
using iHakeem.Application.Patients.PatientGaurdians.CommandHandlers.CreateOrUpdate;
using iHakeem.Application.Patients.PatientGaurdians.CommandHandlers.Delete;
using iHakeem.Application.Patients.PatientGaurdians.QueryHandlers.Detail;
using iHakeem.Application.Patients.PatientSocialInfo.QueryHandler.List;
using iHakeem.Application.Patients.PersonalInfo.CommadHandler.Update;
using iHakeem.Application.Patients.PersonalInfo.QueryHandler.Detail;
using iHakeem.Application.Patients.SocialInfo.CommadHandler.Create;
using iHakeem.Application.Patients.SocialInfo.CommadHandler.Delete;
using iHakeem.Application.Patients.SocialInfo.QueryHandler.Detail;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace iHakeem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ApiControllerBase
    {
        public PatientController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpPost("Signup")]
        public async Task<IActionResult> Signup([FromBody] PatientSignupRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }

        [HttpGet("PersonalInfo")]
        public async Task<IActionResult> PersonalInfo([FromQuery] PatientProfileInfoDetailRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        #region PatientGaudian
        [HttpPost("PatientGaurdian/Create")]
        public async Task<IActionResult> Create([FromBody] CreateOrUpdatePatientGaurdianRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("PatientGaurdian/Update")]
        public async Task<IActionResult> Update([FromBody] CreateOrUpdatePatientGaurdianRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }

        [HttpDelete("PatientGaurdian")]
        public async Task<IActionResult> DeletePatientGaurdian([FromBody] PatientGaurdianDeleteRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("PatientGaurdian")]
        public async Task<IActionResult> GetPatientGaurdian([FromQuery] GetPatientGaurdianRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        [HttpPut("PersonalInfo")]
        public async Task<IActionResult> UpdatePersonalInfo([FromBody] PatientPersonalInfoUpdateRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }

        #endregion


        #region EmergencyContact
        [HttpPost("EmergencyContact/Save")]
        public async Task<IActionResult> SaveEmergencyContact([FromBody] PatientEmergencyContactCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpDelete("EmergencyContact")]
        public async Task<IActionResult> DeleteEmergencyContact([FromBody] PatientEmergencyContactDeleteRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("EmergencyContact")]
        public async Task<IActionResult> GetEmergencyContact([FromBody] PatientEmergencyContactCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpGet("EmergencyContact/List")]
        public async Task<IActionResult> GetEmergencyContactList([FromQuery] PatientEmergencyContactListRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        #endregion
        #region SocialInfo

        [HttpPost("SocialInfo/Save")]
        public async Task<IActionResult> SaveSocialInfo([FromBody] PatientSocialInfoCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpGet("SocialInfo")]
        public async Task<IActionResult> GetSocialInfo([FromQuery] PatientSocialInfoDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpDelete("SocialInfo")]
        public async Task<IActionResult> SaveSocialInfo([FromBody] PatientSocialInfoDeleteRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpGet("SocialInfo/List")]
        public async Task<IActionResult> GetSocialInfoList([FromQuery] PatientSocialInfoListRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        #endregion
    }
}
