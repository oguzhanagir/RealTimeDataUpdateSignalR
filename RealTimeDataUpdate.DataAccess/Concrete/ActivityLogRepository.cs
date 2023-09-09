using RealTimeDataUpdate.DataAccess.Abstract;
using RealTimeDataUpdate.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeDataUpdate.DataAccess.Concrete
{
    public class ActivityLogRepository : GenericRepository<ActivityLog>, IActivityLogRepository
    {
        public ActivityLogRepository(RealTimeDataUpdateDbContext dbContext) : base(dbContext)
        {
        }
    }
}
