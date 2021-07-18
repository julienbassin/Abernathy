namespace Abernathy.Demographics.Service.Models.Entities
{
    public class PatientPhoneNumber
    {
        public int PhoneNumberId { get; set; }
        public virtual PhoneNumber PhoneNumber { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}