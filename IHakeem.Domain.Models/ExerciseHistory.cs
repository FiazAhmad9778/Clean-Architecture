using System;
using System.Collections.Generic;
using iHakeem.SharedKernal.BaseDomain;

namespace iHakeem.Domain.Models
{
    public class ExerciseHistory : AuditEntity<long>
    {
        public ExerciseHistory()
        {
        }
        public bool IsExercise { get; set; }
        public string ExerciseType { get; set; }
        public long? NumberOfDaysPerWeek { get; set; }
        public string HobbiesOrActivitiesNotes { get; set; }
        public long PatientId { get; set; }
        public Patient PatientDetails { get; set; }
    }
}
