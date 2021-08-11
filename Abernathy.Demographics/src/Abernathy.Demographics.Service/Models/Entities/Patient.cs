using System;
using System.Collections.Generic;

namespace Abernathy.Demographics.Service.Models.Entities
{
    public class Patient : IEntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int GenderId { get; set; }
        public Gender type { get; set; }

        // if you want support many phonenumbers
        public List<PatientPhoneNumber> PatientPhoneNumbers { get; set; } = new List<PatientPhoneNumber>();
        public List<PatientAddress> PatientAddresses { get; set; } = new List<PatientAddress>();

        // public int AddressId { get; set; }
        // public Address Address { get; set; }
    }
}