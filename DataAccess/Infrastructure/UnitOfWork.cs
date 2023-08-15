using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private readonly CapstoneRegistrationContext context;

        protected override void DisposeCore()
        {
            if (context != null)
                context.Dispose();
        }
    }
}
