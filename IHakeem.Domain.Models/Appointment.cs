using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Domain.Models
{
    public class Appointment : EntityBase<long>
    {
        public string AppointmentTypeId { get; set; }
        public string AppointmentStatusId { get; set; }
        public long DoctorId { get; set; }
        public long PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal FeeAmount { get; set; }
        public string ClinicLocation { get; set; } // will be given in case of physical appointment
        public string Notes { get; set; }
        public LookupData AppointmentType { get; set; }
        public LookupData AppointmentStatus { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }



    }
}
