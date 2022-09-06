using FluentValidation;
using iHakeem.Application.EMR.CurrentMedication.Contracts;
using MediatR;

namespace iHakeem.Application.EMR.CurrentMedication.CommandHandlers.Edit
{
    public class EditCurrentMedicationRequestDTO : IRequest<CurrentMedicationResponseDTO>
    {
        public long Id { get; set; }
        public long MedicineId { get; set; }
        public string ReasonForTakingMedicine { get; set; }
        public string Dose { get; set; }
        public string DoseFrequentId { get; set; }
        public bool AsNeeded { get; set; }
        public string DoctorName { get; set; }
        public string DoctorNumber { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyNumber { get; set; }
        public string Note { get; set; }


        public class EditCurrentMedicationRequestDTOValidator : AbstractValidator<EditCurrentMedicationRequestDTO>
        {
            public EditCurrentMedicationRequestDTOValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.MedicineId).NotEmpty();
            }
        }
    }

}
