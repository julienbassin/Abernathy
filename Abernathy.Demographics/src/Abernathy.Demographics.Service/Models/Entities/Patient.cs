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
        public Gender Type { get; set; }

        // if you want support many phonenumbers
        public List<PatientPhoneNumber> PatientPhoneNumbers { get; set; } = new List<PatientPhoneNumber>();
        public List<PatientAddress> PatientAddresses { get; set; } = new List<PatientAddress>();
    }
}