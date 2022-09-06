using System;
using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class DetailPregnancies  : AuditEntity<long>
    {
        public DetailPregnancies ()
        {
        }
        public DateTime DeliveryDate { get; set; }
        public long DeliveryTypeId { get; set; }
        public long GenderId { get; set; }
        public string NumberOfPregnancies { get; set; }
        public string NumberOfLivingChildrens { get; set; }
        public string NumberOfAbortions { get; set; }
        public string NumberOfMiscarriages { get; set; }
        public string Notes { get; set; }

        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
