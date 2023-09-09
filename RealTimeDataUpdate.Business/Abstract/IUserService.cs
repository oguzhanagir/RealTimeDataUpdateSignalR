using RealTimeDataUpdate.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RealTimeDataUpdate.Business.Concrete.UserService;

namespace RealTimeDataUpdate.Business.Abstract
{
    public interface IUserService
    {
        LoginResult Login(string mail, string password);
        void Register(User user);
        User FindUserByMail(string mail);
        void LogOut(int id);
    }
}
