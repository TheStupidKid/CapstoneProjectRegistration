using BussinessObject.Models;
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

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public CapstoneRegistrationContext DbContext
        {
            get { return context ?? (context = _dbFactory.Init()); }
        }

        public void SaveChange()
        {
            context.SaveChanges();  
        }
    }
}
