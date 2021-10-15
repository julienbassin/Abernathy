using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.Assessement.Service.Models.Entities
{
    public class AssessmentResult
    {
        public AssessmentResult(int patientId, RiskLevel riskLevel)
        {
            PatientId = patientId;
            RiskLevel = riskLevel;
            TimeCreated = DateTime.Now;
        }

        public int PatientId { get; set; }
        
        // return full patient info + note 
        public RiskLevel RiskLevel { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
