using System;
using System.Collections.Generic;
using Abernathy.Demographics.Service.Models.Entities;

namespace Abernathy.Demographics.Service.Models.DTOs
{
    public record PatientDto(int Id,
                            string FirstName,
                            string LastName,
                            int Age,
                            DateTime DateOfBirth,
                            Gender Type);
    public record CreatedPatientDto(string FirstName,
                            string LastName,
                            int Age,
                            DateTime DateOfBirth,
                            int GenderId,
                            List<PhoneNumberDto> PatientPhoneNumbers,
                            List<AddressDto> PatientAddresses,
                            DateTimeOffset CreatedDate);
    public record UpdatePatientDto(string FirstName,
                            string LastName,
                            int Age,
                            DateTime DateOfBirth,
                            Gender Type,
                            List<PhoneNumberDto> PatientPhoneNumbers,
                            List<AddressDto> PatientAddresses,
                            DateTimeOffset CreatedDate);
}