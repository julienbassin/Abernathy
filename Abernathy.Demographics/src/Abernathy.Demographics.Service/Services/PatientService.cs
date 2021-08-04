using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Abernathy.Demographics.Service.Models.DTOs;
using Abernathy.Demographics.Service.Models.Entities;
using Abernathy.Demographics.Service.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

            var currentPatient = await _unitOfWork.PatientRepository.Find(p =>
                                                                    p.FirstName.Contains(model.FirstName) &&
                                                                    p.LastName.Contains(model.LastName))
                                                                    .FirstOrDefaultAsync(p => p.GenderId == model.GenderId && p.DateOfBirth == model.DateOfBirth);
                                                                    
                                                                    
                                                                    
                                                                    
            if (currentPatient != null)
            {
                throw new ArgumentException($"Error Patient already exists ! ");
            }

            // handle address
            await _handleAddresses(model.PatientAddresses, currentPatient);

            // handle phonenumber
            await _handlePhoneNumbers(model.PatientPhoneNumbers, currentPatient);

            // then map all theses properties to newPatient

            try
            {
                var newPatient = _mapper.Map<Patient>(model);
                _unitOfWork.PatientRepository.Add(newPatient);

                // Create a patient
                var result = _mapper.Map<CreatedPatientDto>(model);
                return result;
            }
            catch (Exception)
            {

                throw;
                _unitOfWork.RollBackAsync();
            }
        }

        private async Task _handlePhoneNumbers(IEnumerable<PhoneNumberDto> phoneNumbers, Patient entity)
        {
            if (phoneNumbers == null || entity == null)
            {
                throw new ArgumentNullException();
            }

            var modelArray = phoneNumbers as PhoneNumberDto[] ?? phoneNumbers.ToArray();

            if (! modelArray.Any())
            {
                foreach (var currentPhoneNumbers in modelArray)
                {
                    await _insertPhoneNumbers(currentPhoneNumbers, entity);
                }
            }

        }

        private async Task _handleAddresses(IEnumerable<AddressDto> addresses, Patient entity)
        {
            if (addresses == null || entity == null)
            {
                throw new ArgumentNullException();
            }

            var modelArray = addresses as AddressDto[] ?? addresses.ToArray();

            if (! modelArray.Any())
            {
                foreach (var currentModel in modelArray)
                {
                    await _insertAddresses(currentModel, entity);
                }
            }
        }

        private async Task _insertPhoneNumbers(PhoneNumberDto currentPhoneNumber, Patient entity)
        {
            var numberToCompare = Regex.Replace(currentPhoneNumber.number, @"[- ().]", "");

            var result = await _unitOfWork.PhoneNumberRepository.Find(ph => ph.number.Contains(numberToCompare)).FirstOrDefaultAsync();
            // current phonenumber does not exist
            if (result == null)
            {
                var phoneNumber = _mapper.Map<PhoneNumber>(currentPhoneNumber);

                _unitOfWork.PhoneNumberRepository.Add(phoneNumber);

                entity.PatientPhoneNumbers.Add(new PatientPhoneNumber
                {
                     Patient = entity,
                     PhoneNumber = phoneNumber

                });
            }
            else if(! entity.PatientPhoneNumbers.Any(pn => pn.PatientId == entity.Id && pn.PhoneNumberId == result.Id))
            {
                entity.PatientPhoneNumbers.Add(new PatientPhoneNumber
                {
                    Patient = entity,
                    PhoneNumber = result

                });
            }         

        }

        private async Task _insertAddresses(AddressDto currentModel, Patient entity)
        {
            // check if address is present
            if (true)
            {

            }

            var result = await _unitOfWork.AddressRepository.Find(pa =>
                                                            pa.StreetName.Contains(currentModel.StreetName) &&
                                                            pa.Town.Contains(currentModel.Town) &&
                                                            pa.ZipCode.Contains(currentModel.ZipCode) &&
                                                            pa.State.Contains(currentModel.State)).FirstOrDefaultAsync();

            if (result == null)
            {
                var address = _mapper.Map<Address>(currentModel);
                _unitOfWork.AddressRepository.Add(result);

                entity.PatientAddresses.Add(new PatientAddress 
                {
                    Patient = entity,
                    Address = address                
                });
            }
            else if(!entity.PatientAddresses.Any(pa => pa.PatientId == entity.Id && pa.AddressId == result.Id))
            {
                entity.PatientAddresses.Add(new PatientAddress
                {
                    Patient = entity,
                    Address = result
                });
            }
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

            // handle address
            await _updateAddresses();

            // handle phonenumber
            await _updatePhoneNumbers();

            // then map all theses properties to newPatient

            var existingPatient = _unitOfWork.PatientRepository.GetById(Id);

            var currentPatient = _mapper.Map<Patient>(model);

            // delete this
            existingPatient.FirstName = currentPatient.FirstName;
            existingPatient.LastName = currentPatient.LastName;
            existingPatient.Age = currentPatient.Age;
            existingPatient.DateOfBirth = currentPatient.DateOfBirth;
            existingPatient.Type = currentPatient.Type;
            existingPatient.PatientAddresses = currentPatient.PatientAddresses;
            existingPatient.PatientPhoneNumbers = currentPatient.PatientPhoneNumbers;

            try
            {
                _unitOfWork.PatientRepository.Update(existingPatient);
                _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
                _unitOfWork.RollBackAsync();
            }
            

        }

        private Task _updatePhoneNumbers(IEnumerable<PhoneNumberDto> addresses, Patient entity)
        {
            throw new NotImplementedException();
        }

        private Task _updateAddresses(IEnumerable<AddressDto> addresses, Patient entity)
        {
            throw new NotImplementedException();
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