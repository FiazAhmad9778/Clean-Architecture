using iHakeem.Application.EMR.PregnanciesHistory.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.Application.EMR.PregnanciesHistory.CommandHandlers.CreateOrUpdate
{
    public class CreateOrUpdatePregnanciesHistoryRequestDTO : IRequest<PregnanciesHistoryResponseDTO>
    {
        public long Id { get; set; }
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
    }
}
