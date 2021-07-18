using System.Collections.Generic;

namespace Abernathy.Demographics.Service.Models.Entities
{
    public class PhoneNumber : EntityBase
    {
        public string phoneNumber { get; set; }
        public List<PatientPhoneNumber> PatientPhoneNumbers { get; set; } = new List<PatientPhoneNumber>();
    }
}