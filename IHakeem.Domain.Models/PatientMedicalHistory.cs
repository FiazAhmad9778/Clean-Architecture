using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class PatientMedicalHistory : AuditEntity<long>
    {
        public PatientMedicalHistory()
        {
        }
        public long DiseaseId { get; set; }
        public string Note { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
