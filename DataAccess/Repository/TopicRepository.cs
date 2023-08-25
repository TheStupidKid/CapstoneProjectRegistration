using BussinessObject.Models;
using DataAccess.Infrastructure;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TopicRepository : GenericRepository<Topic>,ITopicRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Topic> _dbSet;
        public TopicRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Topic>();  
        }

    }
}
