using BussinessObject.Models;
using DataAccess.Infrastructure;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StudentInGroupRepository : GenericRepository<StudentInGroup>, IStudentInGroupRepository
    {
    }
}
