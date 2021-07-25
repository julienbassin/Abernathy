using AutoMapper;

namespace Abernathy.Demographics.Service.Mapping
{
    public class AddressProfile : Profile
    {


        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
    }
}