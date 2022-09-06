using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.EMR.ExerciseHistory.Contracts
{
    public class ExerciseHistoryResponseDTO : AuditEntity<long>
    {
        public bool IsExercise { get; set; }
        public string ExerciseType { get; set; }
        public long? NumberOfDaysPerWeek { get; set; }
        public string HobbiesOrActivitiesNotes { get; set; }
        public long PatientId { get; set; }
    }
}
