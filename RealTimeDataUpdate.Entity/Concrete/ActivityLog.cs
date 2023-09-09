using RealTimeDataUpdate.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeDataUpdate.Entity.Concrete
{
    public class ActivityLog:BaseEntity
    {
        public bool Status { get; set; }
        public DateTime CheckTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


        public ActivityLog()
        {
            CheckTime = DateTime.Now;
        }
    }
}
