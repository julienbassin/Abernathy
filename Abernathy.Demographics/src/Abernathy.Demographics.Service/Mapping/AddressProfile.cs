using Abernathy.Demographics.Service.Models.DTOs;
using Abernathy.Demographics.Service.Models.Entities;
using AutoMapper;

namespace Abernathy.Demographics.Service.Mapping
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<CreatedAddressDto, Address>().ReverseMap();
            CreateMap<UpdateAddressto, Address>().ReverseMap();
        }
    }
}