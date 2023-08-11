using BussinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private CapstoneRegistrationContext context;
        private readonly IStudentRepository _studentRepository;

        public UnitOfWork(IDbFactory dbFactory, IStudentRepository studentRepository)
        {
            _dbFactory = dbFactory;
            _studentRepository=studentRepository;
        }

        public CapstoneRegistrationContext DbContext
        {
            get { return context ?? (context = _dbFactory.Init()); }
        }

        public void SaveChange()
        {
            context.SaveChanges();  
        }
        public IStudentRepository StudentRepository => _studentRepository;
    }
}
