using System.Collections.Generic;
using System.Threading.Tasks;
using Abernathy.Demographics.Service.Models.DTOs;
using Abernathy.Demographics.Service.Repository.Interfaces;
using AutoMapper;

namespace Abernathy.Demographics.Service.Services
{
    public class PatientService : IPatientService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;

        public PatientService(IUnitOfWork unitOfWork,
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> GetAll()
        {
            var entities = await _unitOfWork.PatientRepository.FindAll();

            var result = _mapper.Map<IEnumerable<PatientDto>>(entities);

            return result;
        }

        public async Task<PatientDto> GetPatientById(int Id)
        {
            if (Id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var entity = _unitOfWork.PatientRepository.GetByIdAsync(Id);

            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            var result = _mapper.Map<PatientDto>(entity);

            return patient;
        }
    }
}