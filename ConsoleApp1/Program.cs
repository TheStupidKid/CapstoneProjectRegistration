

using BussinessObject.Models;
using DataAccess.Infrastructure;
using Service;

class Program
{
    static void Main(string[] args)
    {
        CapstoneRegistrationContext context= new CapstoneRegistrationContext();
        IUnitOfWork unitOfWork = new UnitOfWork(context);
        var student = studentService.GetStudent(2);
    } 
     
}   
