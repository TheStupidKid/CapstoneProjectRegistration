using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        CapstoneRegistrationContext context;
        public CapstoneRegistrationContext Init()
        {
            return context ?? (context = new CapstoneRegistrationContext());
        }

        protected override void DisposeCore()
        {
            if (context != null)
                context.Dispose();
        }
    }
}
