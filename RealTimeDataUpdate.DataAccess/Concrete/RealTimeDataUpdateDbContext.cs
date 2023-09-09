using Microsoft.EntityFrameworkCore;
using RealTimeDataUpdate.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeDataUpdate.DataAccess.Concrete
{
    public class RealTimeDataUpdateDbContext:DbContext
    {
        public RealTimeDataUpdateDbContext(DbContextOptions<RealTimeDataUpdateDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
    }
}
