using System.Collections.Generic;

namespace Abernathy.Demographics.Service.Models.Entities
{
    public class PhoneNumber : IEntityBase
    {
        public int Id { get; set; }
        public string number { get; set; }
        public string PhoneType { get; set; }
        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
        //public List<PatientPhoneNumber> PatientPhoneNumbers { get; set; } = new List<PatientPhoneNumber>();
    }
}