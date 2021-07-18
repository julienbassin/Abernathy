using System;
using System.Collections.Generic;

namespace Abernathy.Demographics.Service.Models.Entities
{
    public class Patient : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Type { get; set; }
        public ICollection<PatientPhoneNumber> PatientNumber { get; set; }
        public ICollection<PatientAddress> PatientAddress { get; set; }




    }
}