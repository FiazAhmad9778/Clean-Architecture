using System;
using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class MyPhysicians : AuditEntity<long>
    {
        public MyPhysicians()
        {
        }
        public string PhysicianName { get; set; }
        public string PhysicianLocation { get; set; }
        public string Hospital { get; set; }
        public string PhysicianPhoneNo { get; set; }
        public long? PhysicianSpecialityId { get; set; }
        public string PhysicianNotes { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
