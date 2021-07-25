using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abernathy.Demographics.Service.Models.DTOs;
using Abernathy.Demographics.Service.Models.Entities;
using Abernathy.Demographics.Service.Repository.Interfaces;
using AutoMapper;

namespace Abernathy.Demographics.Service.Services
{
    public class PatientService : IPatientService
    {
        public readonly IUnitOfWork _unitOfWork;
        public IMapper _mapper;

        public PatientService(IUnitOfWork unitOfWork,
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> GetAll()
        {
            var entities = _unitOfWork.PatientRepository.GetAll();

            var result = _mapper.Map<IEnumerable<PatientDto>>(entities);

            return result;
        }

        public async Task<PatientDto> GetPatientById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var entity = _unitOfWork.PatientRepository.GetById(Id);

            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            var result = _mapper.Map<PatientDto>(entity);

            return result;
        }

        public async Task<CreatedPatientDto> Create(CreatedPatientDto model)
        {
            if (model?.PatientPhoneNumbers == null || model?.PatientAddresses == null)
            {
                throw new ArgumentNullException();
            }

            var currentPatient = _unitOfWork.PatientRepository.Find(p =>
                                                                    p.FirstName.Contains(model.FirstName) &&
                                                                    p.LastName.Contains(model.LastName));
            if (currentPatient == null)
            {
                var newPatient = _mapper.Map<Patient>(model);
                _unitOfWork.PatientRepository.Add(newPatient);
            }

            var result = _mapper.Map<CreatedPatientDto>(model);
            return result;
        }

        public void Update(int Id, UpdatePatientDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var existingPatient = _unitOfWork.PatientRepository.GetById(Id);

            var currentPatient = _mapper.Map<Patient>(model);

            existingPatient.FirstName = currentPatient.FirstName;
            existingPatient.LastName = currentPatient.LastName;
            existingPatient.Age = currentPatient.Age;
            existingPatient.DateOfBirth = currentPatient.DateOfBirth;
            existingPatient.Type = currentPatient.Type;
            existingPatient.PatientAddresses = currentPatient.PatientAddresses;
            existingPatient.PatientPhoneNumbers = currentPatient.PatientPhoneNumbers;

            _unitOfWork.PatientRepository.Update(existingPatient);
            _unitOfWork.CommitAsync();

        }


        public void DeletePatientById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var entity = _unitOfWork.PatientRepository.GetById(Id);

            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _unitOfWork.PatientRepository.Delete(entity);

            _unitOfWork.CommitAsync();
        }
    }
}