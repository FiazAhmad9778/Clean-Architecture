using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Application.EMR.CurrentMedication.Contracts
{
    public class CurrentMedicationResponseDTO : AuditEntity<long>
    {
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
        public long PatientId { get; set; }
    }
}
