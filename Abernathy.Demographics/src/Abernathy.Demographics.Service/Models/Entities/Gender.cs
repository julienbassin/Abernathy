using System.Collections.Generic;

namespace Abernathy.Demographics.Service.Models.Entities
{
    public class Gender : EntityBase
    {
        public string gender { get; set; }
        public List<Patient> Patient { get; set; } = new List<Patient>();
    }
}