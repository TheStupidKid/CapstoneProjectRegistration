using BussinessObject.Models;
using DataAccess.Infrastructure;
using DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class Class1
    {
        static void Main(string[] args)
        {
            var context = new CapstoneRegistrationContext() ;
            var unitOfWork = new UnitOfWork(context);
            {
                var studentService = new StudentService(unitOfWork);
                var student = studentService.GetStudentById(2);
                Console.WriteLine(student);
            }
        }
    }
}
