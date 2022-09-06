using iHakeem.SharedKernal.BaseDomain;
using System;

namespace iHakeem.Application.EMR.PregnanciesHistory.Contracts
{
    public class PregnanciesHistoryResponseDTO : AuditEntity<long>
    {
        public string Mammogram { get; set; }
        public string BreastExam { get; set; }
        public string PapSmear { get; set; }
        public long DoYouUseContraceptionId { get; set; }
        public string KindOfContraception { get; set; }
        public string AgeAtFirstMenses { get; set; }
        public string MenstrualPeriods { get; set; }
        public string AgeAtMenopause { get; set; }
        public string HotFlashesOrOtherSymptoms { get; set; }
        public string GynaecologicalConditionsOrProblems { get; set; }
        public string Notes { get; set; }

        public long PatientId { get; set; }
    }
}
