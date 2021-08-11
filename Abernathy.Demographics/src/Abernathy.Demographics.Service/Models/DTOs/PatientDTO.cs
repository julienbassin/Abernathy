using System;
using System.Collections.Generic;
using Abernathy.Demographics.Service.Models.Entities;

namespace Abernathy.Demographics.Service.Models.DTOs
{
    public class PatientDTO
    {
        public PatientDTO()
        {
            Addresses = new List<AddressDTO>();
            PhoneNumbers = new List<PhoneNumberDto>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int GenderId { get; set; }
        public List<AddressDTO> Addresses { get; set; }
        public List<PhoneNumberDto> PhoneNumbers { get; set; }
    }
}