using System.Collections.Generic;
using System.Threading.Tasks;
using Abernathy.Demographics.Service.Models.DTOs;

namespace Abernathy.Demographics.Service.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDTO>> GetAll();
        Task<PatientDTO> GetPatientById(int Id);
        Task<PatientDTO> Create(PatientDTO model);
        //void Update(int Id, UpdatePatientDto model);
        Task Update(PatientDTO model);
        Task DeletePatientById(int Id);
    }
}