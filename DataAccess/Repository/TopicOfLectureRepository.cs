using BussinessObject.Models;
using DataAccess.Infrastructure;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TopicOfLectureRepository : GenericRepository<TopicOfLecture>, ITopicOfLectureRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<TopicOfLecture> _dbset;

        public TopicOfLectureRepository(DbContext context)
        {
            _context = context;
            _dbset = context.Set<TopicOfLecture>();
        }
        public IEnumerable<TopicOfLecture> getByLectureId(int id)
        {
            var topic = _dbset
                        .Where(t=>t.LectureId == id)
                        .ToList();
            return topic;
        }
    }
}
