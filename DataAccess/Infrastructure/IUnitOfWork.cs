﻿using BussinessObject.Models;
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
        IGenericRepository<Student> studentRepository { get; }
        IGenericRepository<Topic> topicRepository { get; }
        IGenericRepository<Lecture> lectureRepository { get; }
        IGenericRepository<Group> groupRepository { get; }
        IGenericRepository<StudentInGroup> studentInGroupRepository { get; }
        void Save();
    }
}
