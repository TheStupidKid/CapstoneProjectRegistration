using BussinessObject.Models;
using DataAccess.Infrastructure;
using DataAccess.Interface;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TopicRepository : GenericRepository<Topic>,ITopicRepository
    {
    }
}
