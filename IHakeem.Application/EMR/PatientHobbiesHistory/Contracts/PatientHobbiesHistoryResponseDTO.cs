using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.EMR.PatientHobbiesHistory.Contracts
{
    public class PatientHobbiesHistoryResponseDTO : AuditEntity<long>
    {
        public string Hobby { get; set; }
        public long PatientId { get; set; }
    }
}
