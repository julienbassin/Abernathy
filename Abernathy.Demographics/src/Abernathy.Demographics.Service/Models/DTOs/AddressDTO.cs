using System;

namespace Abernathy.Demographics.Service.Models.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
    }
}