using FluentValidation;
using iHakeem.Application.EMR.PatientMedicalHistory.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.PatientMedicalHistory.CommandHandlers.Create
{
    public class CreatePatientMedicalHistoryRequestDTO : IRequest<PatientMedicalHistoryResponseDTO>
    {
        public long DiseaseId { get; set; }
        public string Note { get; set; }

        public class CreatePatientMedicalHistoryRequestDTOValidator : AbstractValidator<CreatePatientMedicalHistoryRequestDTO>
        {
            public CreatePatientMedicalHistoryRequestDTOValidator()
            {
                RuleFor(x => x.DiseaseId).NotEmpty();
            }
        }
    }

}
