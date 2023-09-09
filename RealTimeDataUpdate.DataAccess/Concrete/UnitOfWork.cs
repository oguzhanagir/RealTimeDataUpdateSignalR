using RealTimeDataUpdate.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeDataUpdate.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RealTimeDataUpdateDbContext _dbContext;

        public UnitOfWork(RealTimeDataUpdateDbContext dbContext )
        {
            _dbContext = dbContext;
            Users = new UserRepository(_dbContext);
            ActivityLogs = new ActivityLogRepository(_dbContext);
        }

        public IUserRepository Users { get; private set; }
        public IActivityLogRepository ActivityLogs { get; private set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
