using BussinessObject.Models;
using DataAccess.Interface;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CapstoneRegistrationContext _context;
        private bool disposed = false;
        public IStudentRepository studentRepository { get; private set; }
        public IGenericRepository<Group> groupRepository { get; }
        public IGenericRepository<Topic> topicRepository { get; }
        public ILectureRepository lectureRepository { get; private set; }
        public IGenericRepository<StudentInGroup> studentInGroupRepository { get; }

        public IGenericRepository<Semester> semesterRepository { get; }

        public IGenericRepository<StudentInSemester> studentInSemesterRepository { get; }

        public IGenericRepository<TopicOfLecture> topicOfLectureRepository { get; }

        public IGenericRepository<TopicOfSemester> topicOfSemesterRepository { get; }

        public UnitOfWork(CapstoneRegistrationContext context)
        {
            _context = context;
            studentRepository = new StudentRepository(_context);
            groupRepository = new GenericRepository<Group>(_context);
            topicRepository = new GenericRepository<Topic>(_context);
            lectureRepository = new LectureRepository(_context);
            studentInGroupRepository = new GenericRepository<StudentInGroup>(_context);
            semesterRepository = new GenericRepository<Semester>(_context);
            studentInSemesterRepository = new GenericRepository<StudentInSemester>(_context);
            topicOfLectureRepository = new GenericRepository<TopicOfLecture>(_context);
            topicOfSemesterRepository = new GenericRepository<TopicOfSemester>(_context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
