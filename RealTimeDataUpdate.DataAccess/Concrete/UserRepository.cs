using Microsoft.Identity.Client;
using RealTimeDataUpdate.DataAccess.Abstract;
using RealTimeDataUpdate.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeDataUpdate.DataAccess.Concrete
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(RealTimeDataUpdateDbContext dbContext) : base(dbContext)
        {
        }
    }
}
