using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Semester
    {
        public Semester()
        {
            StudentInSemesters = new HashSet<StudentInSemester>();
            TopicOfSemesters = new HashSet<TopicOfSemester>();
        }

        public int Id { get; set; }
        public string Semester1 { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<StudentInSemester> StudentInSemesters { get; set; }
        public virtual ICollection<TopicOfSemester> TopicOfSemesters { get; set; }
    }
}
