using System.Collections.Generic;
using System.Threading.Tasks;
using Abernathy.Demographics.Service.Models.DTOs;

namespace Abernathy.Demographics.Service.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAll();
    }
}