using Abernathy.history.Service.Models.DTOs;
using Abernathy.history.Service.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.history.Service.Extensions
{
    public static class Extensions
    {
        public static NoteDTO AsDto(this Note item)
        {
            return new NoteDTO { 
                Id = item.Id, 
                PatientId = item.PatientId, 
                Title = item.Title, 
                Content =  item.Content };
        }
    }
}
