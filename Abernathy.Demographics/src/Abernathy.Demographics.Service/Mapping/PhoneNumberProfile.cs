using Abernathy.Demographics.Service.Models.DTOs;
using Abernathy.Demographics.Service.Models.Entities;
using AutoMapper;

namespace Abernathy.Demographics.Service.Mapping
{
    public class PhoneNumberProfile : Profile
    {
        public PhoneNumberProfile()
        {
            CreateMap<PhoneNumberDto, PhoneNumber>();
            CreateMap<PhoneNumber, PhoneNumberDto>();
        }
    }
}