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
        private readonly CapstoneRegistrationContext _context;
        private readonly DbSet<Lecture> _dbSet;
        public Lecture checkLogin(string email, string password)
        {
            Lecture lecture = _dbSet.Where(s => s.Email.Equals(email)).FirstOrDefault();
            if (lecture == null || !BC.Verify(password, lecture.Password))
            {
                return null;
            }

            return lecture;
        }
    }
}
