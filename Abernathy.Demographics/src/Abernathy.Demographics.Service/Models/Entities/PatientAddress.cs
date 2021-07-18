namespace Abernathy.Demographics.Service.Models.Entities
{
    public class PatientAddress
    {
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }







    }
}