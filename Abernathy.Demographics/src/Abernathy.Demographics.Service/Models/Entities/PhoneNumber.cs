using System.Collections.Generic;

namespace Abernathy.Demographics.Service.Models.Entities
{
    public class PhoneNumber : EntityBase
    {
        public string phoneNumber { get; set; }
        public ICollection<PatientPhoneNumber> PatientPhoneNumber { get; set; }
    }
}