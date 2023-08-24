using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class TopicOfSemester
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int SemesterId { get; set; }
        public int? Status { get; set; }

        public virtual Semester Semester { get; set; } = null!;
        public virtual Topic Topic { get; set; } = null!;
    }
}
