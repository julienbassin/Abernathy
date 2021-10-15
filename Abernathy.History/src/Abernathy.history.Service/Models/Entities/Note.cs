using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.history.Service.Models.Entities
{
    public class Note : IEntityBase
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedTime { get; set; } = DateTime.UtcNow;
    }
}
