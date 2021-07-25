using System.Collections.Generic;
using System.Threading.Tasks;
using Abernathy.Demographics.Service.Models.DTOs;

namespace Abernathy.Demographics.Service.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAll();
        Task<PatientDto> GetPatientById(int Id);
        Task<CreatedPatientDto> Create(CreatedPatientDto model);
        void Update(int Id, UpdatePatientDto model);
        void DeletePatientById(int Id);
    }
}