using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.EMR.MyPhysicians.Contracts
{
    public class MyPhysiciansResponseDTO : AuditEntity<long>
    {
        public string PhysicianName { get; set; }
        public string PhysicianLocation { get; set; }
        public string Hospital { get; set; }
        public string PhysicianPhoneNo { get; set; }
        public long? PhysicianSpecialityId { get; set; }
        public string PhysicianNotes { get; set; }
        public long PatientId { get; set; }
    }
}
