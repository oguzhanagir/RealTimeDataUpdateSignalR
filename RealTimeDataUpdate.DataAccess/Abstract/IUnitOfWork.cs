using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeDataUpdate.DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IActivityLogRepository ActivityLogs { get; }

        void Save();
    }
}
