namespace Abernathy.Demographics.Service.Models.Entities
{
    public class PatientPhoneNumber
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int PatientId { get; set; }
        public int PhoneTypeId { get; set; }
    }
}