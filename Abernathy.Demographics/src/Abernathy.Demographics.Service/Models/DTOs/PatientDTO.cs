using System;
using System.Collections.Generic;
using Abernathy.Demographics.Service.Models.Entities;

namespace Abernathy.Demographics.Service.Models.DTOs
{
    public record PatientDto(int Id,
                            string FirstName,
                            string LastName);
    public record CreatedPatientDto(int Id,
                            string FirstName,
                            string LastName,
                            int Age,
                            DateTime DateOfBirth,
                            Gender Type,
                            List<PatientPhoneNumber> PatientPhoneNumbers,
                            List<PatientPhoneNumber> PatientAddresses,
                            DateTimeOffset CreatedDate);
    public record UpdatePatientDto(int Id,
                            string FirstName,
                            string LastName,
                            int Age,
                            DateTime DateOfBirth,
                            Gender Type,
                            List<PatientPhoneNumber> PatientPhoneNumbers,
                            List<PatientPhoneNumber> PatientAddresses,
                            DateTimeOffset CreatedDate);
}