using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.EMR.HospitalizationInformation.Contracts
{
    public class HospitalizationInformationResponseDTO : AuditEntity<long>
    {
        public string HospitalName { get; set; }
        public string HospitaliazationYear { get; set; }
        public string PhoneNumber { get; set; }
        public long? ReasonId { get; set; }
        public string location { get; set; }
        public string HospitalizaitonNotes { get; set; }
        public long PatientId { get; set; }
    }
}
