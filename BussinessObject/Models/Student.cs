using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentInGroups = new HashSet<StudentInGroup>();
            StudentInSemesters = new HashSet<StudentInSemester>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime Dob { get; set; }
        public bool Status { get; set; }
        public string? Role { get; set; }

        public virtual ICollection<StudentInGroup> StudentInGroups { get; set; }
        public virtual ICollection<StudentInSemester> StudentInSemesters { get; set; }
    }
}
