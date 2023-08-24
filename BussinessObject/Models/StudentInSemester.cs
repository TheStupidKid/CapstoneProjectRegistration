using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class StudentInSemester
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SemesterId { get; set; }
        public int? CurrentSemester { get; set; }

        public virtual Semester Semester { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
