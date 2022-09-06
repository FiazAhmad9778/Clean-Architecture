using System;

namespace iHakeem.Application.Doctors.References.Contracts
{
    public class DoctorReferenceDTO
    {
        public int Id { get; set; }
        public long DoctorId { get; set; }
        public string RelationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Fax { get; set; }
        public string DurationAssociated { get; set; }
    }
}
