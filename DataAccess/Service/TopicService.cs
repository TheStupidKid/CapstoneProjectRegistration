using BussinessObject.Models;
using DataAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class TopicService
    {
        private readonly IUnitOfWork unitOfWork;

        public TopicService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Topic> GetTopics()
        {
            return unitOfWork.topicRepository.GetAll();
        }
             
    }
}
