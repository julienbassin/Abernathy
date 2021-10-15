using Abernathy.Assessement.Service.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.Assessement.Service.Services.Interfaces
{
    public interface IAssessementService
    {
        Task<AssessmentResult> GenerateDiabetesReport(int patientId);
    }
}
