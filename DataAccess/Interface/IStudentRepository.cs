using BussinessObject.Models;
using DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Student checkLogin(string email, string password);
        Student register(Student student);
        Student getByStudentCode(string studentCode);   
    }
}
