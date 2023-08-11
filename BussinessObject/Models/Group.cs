using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Group
    {
        public Group()
        {
            StudentInGroups = new HashSet<StudentInGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumOfMember { get; set; }
        public int TopicId { get; set; }
        public int LectureId { get; set; }
        public bool Status { get; set; }

        public virtual Lecture Lecture { get; set; } = null!;
        public virtual Topic Topic { get; set; } = null!;
        public virtual ICollection<StudentInGroup> StudentInGroups { get; set; }
    }
}
