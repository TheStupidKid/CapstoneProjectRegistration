using BussinessObject.Models;
using DataAccess.Infrastructure;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);

    }
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Student> GetStudents()
        {
            var students = unitOfWork.StudentRepository.GetAll();
            return students;
        }

        public Student GetStudent(int id)
        {
            var student = unitOfWork.StudentRepository.GetById(id);
            return student;
        }

        public void CreateStudent(Student student)
        {
            unitOfWork.StudentRepository.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            unitOfWork.StudentRepository.Update(student);
        }
    }
}
