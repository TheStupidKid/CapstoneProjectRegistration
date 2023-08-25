using BussinessObject.Models;
using DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class LectureService
    {
        private readonly IUnitOfWork unitOfWork;

        public LectureService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Lecture Login(string email, string password)
        {
            return unitOfWork.lectureRepository.checkLogin(email, password);
        }
    }
}
