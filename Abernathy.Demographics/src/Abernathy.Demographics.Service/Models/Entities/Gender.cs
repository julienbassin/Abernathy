using System.Collections.Generic;

namespace Abernathy.Demographics.Service.Models.Entities
{
    public class Gender : EntityBase
    {
        public string gender { get; set; }
        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}