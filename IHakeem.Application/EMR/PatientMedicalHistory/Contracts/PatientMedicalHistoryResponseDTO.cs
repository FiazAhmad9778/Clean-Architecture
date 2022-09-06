using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Application.EMR.PatientMedicalHistory.Contracts
{
    public class PatientMedicalHistoryResponseDTO : AuditEntity<long>
    {
        public long DiseaseId { get; set; }
        public string Note { get; set; }
        public long PatientId { get; set; }
    }
}
