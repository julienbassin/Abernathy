using System.Collections.Generic;
using System.Threading.Tasks;
using Abernathy.Demographics.Service.Models.DTOs;

namespace Abernathy.Demographics.Service.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDTO>> GetAllPatients();
        Task<PatientDTO> GetPatientById(int Id);
        Task<PatientDTO> CreatePatient(PatientDTO model);
        //void Update(int Id, UpdatePatientDto model);
        Task UpdatePatient(int Id, PatientDTO model);
        Task DeletePatientById(int Id);
    }
}