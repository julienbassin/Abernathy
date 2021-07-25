namespace Abernathy.Demographics.Service.Models.Entities
{
    public class PatientAddress
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}