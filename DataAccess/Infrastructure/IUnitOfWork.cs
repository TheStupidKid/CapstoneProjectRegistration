using BussinessObject.Models;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository studentRepository { get; }
        IGenericRepository<Topic> topicRepository { get; }
        ILectureRepository lectureRepository { get; }
        IGenericRepository<Group> groupRepository { get; }
        IGenericRepository<StudentInGroup> studentInGroupRepository { get; }
        IGenericRepository<Semester> semesterRepository { get; }
        IGenericRepository<StudentInSemester> studentInSemesterRepository { get; }
        IGenericRepository<TopicOfLecture> topicOfLectureRepository { get; }
        IGenericRepository<TopicOfSemester> topicOfSemesterRepository { get; }
        void Save();
    }
}
