using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Topic
    {
        public Topic()
        {
            Groups = new HashSet<Group>();
            TopicOfLectures = new HashSet<TopicOfLecture>();
            TopicOfSemesters = new HashSet<TopicOfSemester>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<TopicOfLecture> TopicOfLectures { get; set; }
        public virtual ICollection<TopicOfSemester> TopicOfSemesters { get; set; }
    }
}
