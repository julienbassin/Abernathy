using Abernathy.Assessement.Service.Models.Entities;
using Abernathy.Assessement.Service.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.Assessement.Service.Services
{
    public class AssessementService : IAssessementService
    {
        private readonly IExternalHistoryService _historyService;
        private readonly IExternalDemographicsService _demographicsService;
        private readonly IConfiguration _configuration;

        public AssessementService(IExternalHistoryService historyService,
                                IExternalDemographicsService demographicsService,
                                IConfiguration configuration)
        {
            _historyService = historyService;
            _demographicsService = demographicsService;
            _configuration = configuration;
        }

        public async Task<AssessmentResult> GenerateDiabetesReport(int patientId)
        {

            var triggerCount = await CheckNotes(patientId);

            var currentPatient = await _demographicsService.GetPatientById(patientId);


            var result = triggerCount == 0 ?
                new AssessmentResult(patientId, RiskLevel.None) :
                GetPatientInfo(currentPatient, triggerCount);

            return result;
        }

        public AssessmentResult GetPatientInfo(PatientModel patient, int triggerCount)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }
           
            //var currentPatient = _demographicsService.GetPatientById(patient.Id);

            RiskLevel riskLevel;

            if (patient.Age < 30)
            {
                riskLevel = PatientUnder30(patient.GenderId, triggerCount);
            }
            else
            {
                riskLevel = PatientOver30(patient.GenderId, triggerCount);
            }

            var assessmentResult = new AssessmentResult(patient.Id, riskLevel);
            return assessmentResult;
        }

        public RiskLevel PatientOver30(int genderId, int triggerCount)
        {
            RiskLevel riskLevel;
            switch (genderId)
            {
                case 1 when triggerCount >=8:
                    riskLevel = RiskLevel.EarlyOnSet;
                    break;
                case 2 when triggerCount >=8:
                    riskLevel = RiskLevel.EarlyOnSet;
                    break;

                case 1 when triggerCount == 6:
                    riskLevel = RiskLevel.InDanger;
                    break;
                case 2 when triggerCount == 6:
                    riskLevel = RiskLevel.InDanger;
                    break;

                case 1 when triggerCount == 2:
                    riskLevel = RiskLevel.BorderLine;
                    break;
                case 2 when triggerCount == 2:
                    riskLevel = RiskLevel.BorderLine;
                    break;

                default:
                    riskLevel = RiskLevel.None;
                    break;
            }

            return riskLevel;
        }

        public RiskLevel PatientUnder30(int genderId, int triggerCount)
        {
            // indanger, earlyonset over 30yo

            RiskLevel riskLevel;
            switch (genderId)
            {
                case 1 when triggerCount <= 4:
                    riskLevel = RiskLevel.InDanger;
                    break;
                case 2 when triggerCount <= 4:
                    riskLevel = RiskLevel.InDanger;
                    break;

                case 1 when triggerCount == 5:
                    riskLevel = RiskLevel.EarlyOnSet;
                    break;
                case 2 when triggerCount == 7:
                    riskLevel = RiskLevel.EarlyOnSet;
                    break;

                default:
                    riskLevel = RiskLevel.None;
                    break;
            }

            return riskLevel;
        }

        private async Task<int> CheckNotes(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Id));
            }

            var currentNotes = await _historyService.GetNotesPatientById(Id);

            var words = _configuration.GetSection("Words").GetChildren().ToList();

            var result = new List<string>();

            foreach (var note in currentNotes)
            {
                foreach (var word in words)
                {
                    if (! result.Any( w => w.Contains(word.Value, StringComparison.OrdinalIgnoreCase)) && 
                                    (note.Content.Contains(word.Value, StringComparison.OrdinalIgnoreCase)))
                    {
                        result.Add(word.Value);
                    }
                }
            }

            return result.Count;
        }        
    }
}
