using System.Collections.Generic;

namespace Abernathy.Demographics.Service.Models.Entities
{
    public class Address : IEntityBase
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
    }
}