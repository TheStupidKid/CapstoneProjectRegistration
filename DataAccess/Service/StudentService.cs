using BussinessObject.Models;
using DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class StudentService
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentService (IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Student GetStudentById(int id)
        {
            return unitOfWork.studentRepository.GetById(id);
        }
    }
}
