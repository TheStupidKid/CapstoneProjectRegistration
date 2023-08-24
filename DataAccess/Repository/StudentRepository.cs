using BussinessObject.Models;
using DataAccess.Infrastructure;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace DataAccess.Repository
{
    public class StudentRepository : GenericRepository<Student>,IStudentRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Student> _dbSet;
        public StudentRepository(DbContext context) {
            _context= context;
        }
        public Student checkLogin(string email, string password)
        {
            Student student = _context.Set<Student>().FirstOrDefault(e=>e.Email == email && e.Password==password);
            /*if(student == null || !BC.Verify(password,student.Password)) 
            {
                return null;
            }*/

            return student;
        }
        public Student register(Student student)
        {
            student.Status = true;
            student.Role = "Student";
            student.Password = BC.HashPassword(student.Password);
            _dbSet.Add(student);
            _context.SaveChanges();
            return student;
        }
        public Student getByStudentCode(string studentCode)
        {
            Student student = _dbSet.Where(s=>s.Code.Equals(studentCode)).FirstOrDefault();
            return student;
        }
    }
}
