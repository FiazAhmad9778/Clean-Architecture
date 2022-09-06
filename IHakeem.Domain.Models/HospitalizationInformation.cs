using System;
using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class HospitalizationInformation : AuditEntity<long>
    {
        public HospitalizationInformation()
        {
        }
        public string HospitalName { get; set; }
        public string HospitaliazationYear { get; set; }
        public string PhoneNumber { get; set; }
        public long? ReasonId { get; set; }
        public string location { get; set; }
        public string HospitalizaitonNotes { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
