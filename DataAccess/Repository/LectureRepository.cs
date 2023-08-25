using BussinessObject.Models;
using DataAccess.Infrastructure;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace DataAccess.Repository
{
    public class LectureRepository : GenericRepository<Lecture>, ILectureRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Lecture> _dbSet;
        public LectureRepository(DbContext context)
        {
            _context = context;
        }
        public Lecture checkLogin(string email, string password)
        {
            Lecture lecture = _context.Set<Lecture>().FirstOrDefault(e => e.Email == email && e.Password == password);
            /*if (lecture == null || !BC.Verify(password, lecture.Password))
            {
                return null;
            }*/

            return lecture;
        }
    }
}
