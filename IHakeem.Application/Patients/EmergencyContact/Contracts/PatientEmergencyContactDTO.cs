namespace iHakeem.Application.Patients.EmergencyContact.Contracts
{
    public class PatientEmergencyContactDTO
    {
        public int Id { get; set; }
        public long PatientId { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string RelationId { get; set; }
    }
}
