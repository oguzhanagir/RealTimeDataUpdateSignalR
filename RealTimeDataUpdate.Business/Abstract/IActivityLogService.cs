using RealTimeDataUpdate.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeDataUpdate.Business.Abstract
{
    public interface IActivityLogService:IGenericService<ActivityLog>
    {
        IEnumerable<ActivityLog> GetAllByUserId(int id);
    }
}
