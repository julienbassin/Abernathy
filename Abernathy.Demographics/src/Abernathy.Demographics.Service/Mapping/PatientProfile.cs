using Abernathy.Demographics.Service.Models.DTOs;
using Abernathy.Demographics.Service.Models.Entities;
using AutoMapper;

namespace Abernathy.Demographics.Service.Mapping
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<PatientDTO, Patient>();
            //CreateMap<Patient, PatientDTO>().ForMember(
            //    dest => dest.PhoneNumbers,
            //    opt => opt.MapFrom(src => src.PatientPhoneNumbers)
            //);
            CreateMap<Patient, PatientDTO>();

            
        }
    }
}