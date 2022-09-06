using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.EMR.DetailPregnancies.Contracts
{
    public class DetailPregnanciesResponseDTO : AuditEntity<long>
    {
        public DateTime DeliveryDate { get; set; }
        public long DeliveryTypeId { get; set; }
        public long GenderId { get; set; }
        public string NumberOfPregnancies { get; set; }
        public string NumberOfLivingChildrens { get; set; }
        public string NumberOfAbortions { get; set; }
        public string NumberOfMiscarriages { get; set; }
        public string Notes { get; set; }

        public long PatientId { get; set; }
    }
}
