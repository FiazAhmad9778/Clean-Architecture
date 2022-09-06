using FluentValidation;
using iHakeem.Application.EMR.PatientMedicalHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PatientMedicalHistory.CommandHandlers.Edit
{
    public class EditPatientMedicalHistoryRequestDTO : IRequest<PatientMedicalHistoryResponseDTO>
    {
        public long Id { get; set; }
        public long DiseaseId { get; set; }
        public string Note { get; set; }


        public class EditPatientMedicalHistoryRequestDTOValidator : AbstractValidator<EditPatientMedicalHistoryRequestDTO>
        {
            public EditPatientMedicalHistoryRequestDTOValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.DiseaseId).NotEmpty();
            }
        }
    }

}
