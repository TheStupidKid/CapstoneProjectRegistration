using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Common
{
    public interface ICurrentTime
    {
        public DateTime CurrentTime();
    }
    public class CurrentTime : ICurrentTime
    {
        DateTime ICurrentTime.CurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}
