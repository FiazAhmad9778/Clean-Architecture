#region NameSpaces
using iHakeem.Application.Doctors.AwardsAndRecognitions.CommadHandler.Delete;
using iHakeem.Application.Doctors.AwardsAndRecognitions.QueryHandler.Detail;
using iHakeem.Application.Doctors.AwardsAndRecognitions.QueryHandler.List;
using iHakeem.Application.Doctors.CommandHandler.Signup;
using iHakeem.Application.Doctors.DoctorAwardsAndRecognitions.CommadHandler.Create;
using iHakeem.Application.Doctors.DoctorServices.CommadHandler.Create;
using iHakeem.Application.Doctors.Education.CommadHandler.Create;
using iHakeem.Application.Doctors.Education.CommadHandler.Delete;
using iHakeem.Application.Doctors.Education.QueryHandler.Detail;
using iHakeem.Application.Doctors.Education.QueryHandler.List;
using iHakeem.Application.Doctors.LicenseAndCertification.CommadHandler.Create;
using iHakeem.Application.Doctors.LicenseAndCertification.CommadHandler.Delete;
using iHakeem.Application.Doctors.LicenseAndCertification.QueryHandler.Detail;
using iHakeem.Application.Doctors.LicenseAndCertification.QueryHandler.List;
using iHakeem.Application.Doctors.Memberships.CommadHandler.Create;
using iHakeem.Application.Doctors.Memberships.CommadHandler.Delete;
using iHakeem.Application.Doctors.Memberships.QueryHandler.Detail;
using iHakeem.Application.Doctors.Memberships.QueryHandler.List;
using iHakeem.Application.Doctors.PersonalInfo.CommadHandler.Update;
using iHakeem.Application.Doctors.PersonalInfo.QueryHandler.Detail;
using iHakeem.Application.Doctors.Reference.CommadHandler.Create;
using iHakeem.Application.Doctors.References.CommadHandler.Delete;
using iHakeem.Application.Doctors.References.QueryHandler.Detail;
using iHakeem.Application.Doctors.References.QueryHandler.List;
using iHakeem.Application.Doctors.Services.CommadHandler.Delete;
using iHakeem.Application.Doctors.Services.QueryHandler.Detail;
using iHakeem.Application.Doctors.Services.QueryHandler.List;
using iHakeem.Application.Doctors.SkillsAndtraining.CommadHandler.Create;
using iHakeem.Application.Doctors.SkillsAndtraining.CommadHandler.Delete;
using iHakeem.Application.Doctors.SkillsAndtraining.QueryHandler.Detail;
using iHakeem.Application.Doctors.SkillsAndtraining.QueryHandler.List;
using iHakeem.Application.Doctors.SocialInfo.CommadHandler.Create;
using iHakeem.Application.Doctors.SocialInfo.CommadHandler.Delete;
using iHakeem.Application.Doctors.SocialInfo.QueryHandler.Detail;
using iHakeem.Application.Doctors.SocialInfo.QueryHandler.List;
using iHakeem.Application.Doctors.WorkExperience.CommadHandler.Create;
using iHakeem.Application.Doctors.WorkExperience.CommadHandler.Delete;
using iHakeem.Application.Doctors.WorkExperience.QueryHandler.Detail;
using iHakeem.Application.Doctors.WorkExperience.QueryHandler.List;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace iHakeem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor")]
    public class DoctorController : ApiControllerBase
    {
        public DoctorController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        #region Register

        [HttpPost("Signup")]
        [AllowAnonymous]
        public async Task<IActionResult> Signup([FromBody] DoctorSignupRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        #endregion
        #region PersonalInfo

        [HttpGet("PersonalInfo")]
        public async Task<IActionResult> PersonalInfo([FromQuery] DoctorPersonalInfoDetailRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }

        [HttpPut("PersonalInfo")]
        public async Task<IActionResult> UpdatePersonalInfo([FromBody] DoctorPersonalInfoUpdateRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }

        #endregion
        #region Education
        [HttpPost("Education/Save")]
        public async Task<IActionResult> SaveEmergencyContact([FromBody] DoctorEducationCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("Education")]
        public async Task<IActionResult> DeleteEmergencyContact([FromBody] DoctorEducationDeleteRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("Education")]
        public async Task<IActionResult> GetEmergencyContact([FromQuery] DoctorEducationDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpGet("Education/List")]
        public async Task<IActionResult> GetEmergencyContactList([FromQuery] DoctorEducationListRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        #endregion

        #region SkillsAndTraining
        [HttpPost("SkillsAndTraining/Save")]
        public async Task<IActionResult> SaveEmergencyContact([FromBody] DoctorSkillsAndTrainingCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpDelete("SkillsAndTraining")]
        public async Task<IActionResult> DeleteEmergencyContact([FromBody] DoctorSkillsAndTrainingDeleteRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("SkillsAndTraining")]
        public async Task<IActionResult> GetEmergencyContact([FromQuery] DoctorSkillsAndtrainingDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpGet("SkillsAndTraining/List")]
        public async Task<IActionResult> GetEmergencyContactList([FromQuery] DoctorSkillsAndTrainingListRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        #endregion

        #region Services
        [HttpPost("Services/Save")]
        public async Task<IActionResult> SaveDoctorServices([FromBody] DoctorServiceCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("Services")]
        public async Task<IActionResult> DeleteDoctorServices([FromBody] DoctorServiceDeleteRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("Services")]
        public async Task<IActionResult> GetDoctorServices([FromQuery] DoctorServiceDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpGet("Services/List")]
        public async Task<IActionResult> GetDoctorServiceList([FromQuery] DoctorServiceListRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        #endregion


        #region WorkExperience

        [HttpPost("WorkExperiences/Save")]
        public async Task<IActionResult> SaveWorkExperiences([FromBody] DoctorWorkExperienceCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("WorkExperiences")]
        public async Task<IActionResult> DeleteWorkExperiences([FromBody] DoctorWorkExperienceDeleteRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("WorkExperiences")]
        public async Task<IActionResult> GetWorkExperiences([FromQuery] DoctorWorkExperienceDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpGet("WorkExperiences/List")]
        public async Task<IActionResult> GetWorkExperienceList([FromQuery] DoctorWorkExperienceListRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        #endregion
        #region References
        [HttpPost("References/Save")]
        public async Task<IActionResult> SaveReferences([FromBody] DoctorReferenceCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("References")]
        public async Task<IActionResult> DeleteReferences([FromBody] DoctorReferenceDeleteRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("References")]
        public async Task<IActionResult> GetReferences([FromQuery] DoctorReferenceDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpGet("References/List")]
        public async Task<IActionResult> GetReferenceList([FromQuery] DoctorReferenceListRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        #endregion
        #region LiccenseAndCertifications
        [HttpPost("LicenseAndCertifications/Save")]
        public async Task<IActionResult> SaveLicenseAndCertifications([FromBody] DoctorLicenseAndCertificationCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("LicenseAndCertifications")]
        public async Task<IActionResult> GetLicenseAndCertification([FromBody] DoctorLicenseAndCertificationDeleteRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("LicenseAndCertifications")]
        public async Task<IActionResult> DeleteLicenseAndCertification([FromQuery] DoctorLicenseAndCertificationDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpGet("LicenseAndCertifications/List")]
        public async Task<IActionResult> GetLicenseAndCertificationList([FromQuery] DoctorLicenseAndCertificationListRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        #endregion

        #region Membership
        [HttpPost("Memberships/Save")]
        public async Task<IActionResult> SaveMemberships([FromBody] DoctorMembershipCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("Memberships")]
        public async Task<IActionResult> DeleteMemberships([FromBody] DoctorMembershipDeleteRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("Memberships")]
        public async Task<IActionResult> GetMemberships([FromQuery] DoctorMembershipDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("Memberships/List")]
        public async Task<IActionResult> GetMembershipList([FromQuery] DoctorMembershipListRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        #endregion
        #region AwardsAndRecognition
        [HttpPost("AwardsAndRecognitions/Save")]
        public async Task<IActionResult> SaveAwardsAndRecognitions([FromBody] DoctorAwardsAndRecognitionCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpDelete("AwardsAndRecognition")]
        public async Task<IActionResult> DeleteAwardsAndRecognitions([FromBody] DoctorAwardsAndRecognitionDeleteRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("AwardsAndRecognition")]
        public async Task<IActionResult> GetAwardsAndRecognitions([FromQuery] DoctorAwardsAndRecognitionDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }
        [HttpGet("AwardsAndRecognitions/List")]
        public async Task<IActionResult> GetAwardsAndRecognitionList([FromQuery] DoctorAwardsAndRecognitionListRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        #endregion

        #region SocialInfo

        [HttpPost("SocialInfo/Save")]
        public async Task<IActionResult> SaveSocialInfo([FromBody] DoctorSocialInfoCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpGet("SocialInfo")]
        public async Task<IActionResult> GetSocialInfo([FromQuery] DoctorSocialInfoDetailRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpDelete("SocialInfo")]
        public async Task<IActionResult> SaveSocialInfo([FromBody] DoctorSocialInfoDeleteRequestDTO request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);
            return HandleResponse(response);
        }

        [HttpGet("SocialInfo/List")]
        public async Task<IActionResult> GetSocialInfoList([FromQuery] DoctorSocialInfoListRequestDTO query, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(query, cancellationToken);
            return HandleResponse(response);
        }
        #endregion
    }
}
