using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Lecture
    {
        public Lecture()
        {
            Groups = new HashSet<Group>();
            TopicOfLectures = new HashSet<TopicOfLecture>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<TopicOfLecture> TopicOfLectures { get; set; }
    }
}
