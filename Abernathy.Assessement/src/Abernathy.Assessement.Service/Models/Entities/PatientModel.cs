using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.Assessement.Service.Models.Entities
{
    public class PatientModel 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
    }
}
