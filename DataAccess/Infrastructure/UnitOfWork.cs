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
        public IGenericRepository<Student> studentRepository { get; }
        public IGenericRepository<Group> groupRepository { get; }
        public IGenericRepository<Topic> topicRepository { get; }
        public IGenericRepository<Lecture> lectureRepository { get; }

        public IGenericRepository<StudentInGroup> studentInGroupRepository { get; }
        public UnitOfWork(CapstoneRegistrationContext context)
        {
            _context = context;
            studentRepository = new GenericRepository<Student>(_context);
            groupRepository = new GenericRepository<Group>(_context);
            topicRepository = new GenericRepository<Topic>(_context);
            lectureRepository = new GenericRepository<Lecture>(_context);
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
