using System.Collections.Generic;

namespace Abernathy.Demographics.Service.Models.Entities
{
    public class PhoneNumber : IEntityBase
    {
        public int Id { get; set; }
        public string PhoneType { get; set; }
    }
}