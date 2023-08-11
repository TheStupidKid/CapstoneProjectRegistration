using BussinessObject.Models;
using DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IStudentRepository : IGenericRepository<Student> { }
}
