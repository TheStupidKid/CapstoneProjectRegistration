using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class TopicOfLecture
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int LectureId { get; set; }

        public virtual Lecture Lecture { get; set; } = null!;
        public virtual Topic Topic { get; set; } = null!;
    }
}
