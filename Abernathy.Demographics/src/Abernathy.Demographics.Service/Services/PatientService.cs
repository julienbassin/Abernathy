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

        public Task<IEnumerable<PatientDto>> GetAll()
        {
            // _unitOfWork.PatientRepository.
            return null;
        }
    }
}