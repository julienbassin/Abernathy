using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.Assessement.Service.Models.Entities
{
    public class NoteModel
    {
        public int PatientId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
