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

        public async Task<IEnumerable<PatientDTO>> GetAllPatients()
        {
            var entities = _unitOfWork.PatientRepository.GetAll(null, null, p => p.Addresses, p => p.PhoneNumbers);

            var result = _mapper.Map<IEnumerable<PatientDTO>>(entities);

            return result;
        }

        public async Task<PatientDTO> GetPatientById(int Id)
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

            var result = _mapper.Map<PatientDTO>(entity);

            return result;
        }

        public async Task<PatientDTO> CreatePatient(PatientDTO model)
        {

            var currentPatient = _unitOfWork.PatientRepository.Find(p =>
                                                                    p.FirstName.Contains(model.FirstName) &&
                                                                    p.LastName.Contains(model.LastName) &&
                                                                    p.GenderId == model.GenderId && p.DateOfBirth == model.DateOfBirth)                                                                    
                                                                    .FirstOrDefault();
                                                                                                                     
                                                                    
            if (currentPatient != null)
            {
                throw new ArgumentException($"Error Patient already exists ! ");
            }

            var patient = new Patient
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                DateOfBirth = model.DateOfBirth,
                GenderId = model.GenderId                
            };

            // handle address
            _handleAddresses(model.Addresses, patient);

            // handle phonenumber
            _handlePhoneNumbers(model.PhoneNumbers, patient);

            try
            {
                var currentModel = _mapper.Map<Patient>(model);
                _unitOfWork.PatientRepository.Add(currentModel);
                _unitOfWork.CommitAsync();

                var result = _mapper.Map<PatientDTO>(model);
                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"{ex.Message}");
                await _unitOfWork.RollBackAsync();
            }
        }

        private async Task _handlePhoneNumbers(IEnumerable<PhoneNumberDto> phoneNumbers, Patient entity)
        {
            if (phoneNumbers == null || entity == null)
            {
                throw new ArgumentNullException();
            }

            var modelArray = phoneNumbers as PhoneNumberDto[] ?? phoneNumbers.ToArray();

            if (modelArray.Any())
            {
                foreach (var currentPhoneNumbers in modelArray)
                {
                    await _insertPhoneNumbers(currentPhoneNumbers, entity);
                }
            }

        }

        private async Task _handleAddresses(IEnumerable<AddressDTO> addresses, Patient entity)
        
        {
            if (addresses == null || entity == null)
            {
                throw new ArgumentNullException();
            }

            var modelArray = addresses as AddressDTO[] ?? addresses.ToArray();

            if (modelArray.Any())
            {
                foreach (var currentModel in modelArray)
                {
                    await _insertAddresses(currentModel, entity);
                }
            }
        }

        private async Task _insertPhoneNumbers(PhoneNumberDto currentPhoneNumber, Patient entity)
        {
            var numberToCompare = Regex.Replace(currentPhoneNumber.number, @"[- ().+]", "");

            var result = await _unitOfWork.PhoneNumberRepository.Find(ph => ph.number.Contains(numberToCompare)).FirstOrDefaultAsync();
            // current phonenumber does not exist
            if (result == null)
            {
                var phoneNumber = _mapper.Map<PhoneNumber>(currentPhoneNumber);

                _unitOfWork.PhoneNumberRepository.Add(phoneNumber);

                entity.PhoneNumbers.Add(new PhoneNumber
                {
                    number = currentPhoneNumber.number,
                    PhoneType = currentPhoneNumber.PhoneType
                });
            }
            else
            {
                entity.PhoneNumbers = new List<PhoneNumber>();

                entity.PhoneNumbers.Add(new PhoneNumber
                {
                    number = result.number,
                    PhoneType = result.PhoneType
                });
            }         

        }

        private async Task _insertAddresses(AddressDTO currentModel, Patient entity)
        {

            if (! entity.Addresses.Any())
            {
                entity.Addresses.Add(new Address
                {
                    HouseNumber = currentModel.HouseNumber,
                    StreetName = currentModel.StreetName,
                    Town = currentModel.Town,
                    ZipCode = currentModel.ZipCode,
                    State = currentModel.State
                });

                var address = _mapper.Map<Address>(currentModel);
                _unitOfWork.AddressRepository.Add(address);
            }
            else
            {
                entity.Addresses = new List<Address>();

                entity.Addresses.Add(new Address
                {
                     HouseNumber = currentModel.HouseNumber,
                     StreetName = currentModel.StreetName,
                     Town = currentModel.Town,
                     ZipCode = currentModel.ZipCode,
                     State = currentModel.State
                });
            }
        }

        public async Task UpdatePatient(int Id, PatientDTO model)
        {

            var existingPatient = _unitOfWork.PatientRepository.GetFirstOrDefault(p => p.Id == Id, p => p.Addresses, p => p.PhoneNumbers);

            var currentPatient = _mapper.Map<Patient>(existingPatient);

            try
            {
                // handle address
                await _updateAddresses(model.Addresses, currentPatient);
                _unitOfWork.PatientRepository.Update(currentPatient);

                // handle phonenumber
                await _updatePhoneNumbers(model.PhoneNumbers, currentPatient);
                _unitOfWork.PatientRepository.Update(currentPatient);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
                _unitOfWork.RollBackAsync();
            }        

        }

        private async Task _updatePhoneNumbers(IEnumerable<PhoneNumberDto> phoneNumbers, 
                                                Patient entity)
        {
            if (phoneNumbers == null || entity == null)
            {
                throw new ArgumentNullException();
            }

            var modelArray = phoneNumbers as PhoneNumberDto[] ?? phoneNumbers.ToArray();
            // match the right number and/or both of them

            if (modelArray.Any())
            {
                foreach (var currentModel in modelArray)
                {
                    await _insertPhoneNumbers(currentModel, entity);
                }
            }
        }

        private async Task _updateAddresses(IEnumerable<AddressDTO> addresses, 
                                        Patient entity)
        {
            if (addresses == null || entity == null)
            {
                throw new ArgumentNullException();
            }

            var modelArray = addresses as AddressDTO[] ?? addresses.ToArray();

            if (modelArray.Any())
            {
                foreach (var currentModel in modelArray)
                {
                    await _insertAddresses(currentModel, entity);
                }
            }
        }

        public async Task DeletePatientById(int Id)
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