using Abernathy.Demographics.Service.Models.DTOs;
using Abernathy.Demographics.Service.Models.Entities;
using AutoMapper;

namespace Abernathy.Demographics.Service.Mapping
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<PatientDto, Patient>().ReverseMap();
            CreateMap<UpdatePatientDto, Patient>().ReverseMap();
            CreateMap<CreatedPatientDto, Patient>().ReverseMap();
        }
    }
}