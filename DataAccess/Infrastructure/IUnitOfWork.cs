using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        public void SaveChange();   
        public IStudentRepository StudentRepository { get; }
    }
}
