using System.Collections.Generic;

namespace Abernathy.Demographics.Service.Models.Entities
{
    public class Gender : IEntityBase
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}