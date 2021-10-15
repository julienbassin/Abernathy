using Abernathy.history.Service.Models.DTOs;
using Abernathy.history.Service.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.history.Service.Models.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteDTO>();
            CreateMap<NoteDTO, Note>();
        }
    }
}
