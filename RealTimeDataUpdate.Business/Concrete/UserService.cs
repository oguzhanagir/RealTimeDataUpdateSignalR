using RealTimeDataUpdate.Business.Abstract;
using RealTimeDataUpdate.DataAccess.Abstract;
using RealTimeDataUpdate.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeDataUpdate.Business.Concrete
{
    public class UserService : IUserService
    {
        public enum LoginResult
        {
            Success,
            Failure,
        }

        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public LoginResult Login(string mail, string password)
        {
            var user = _unitOfWork.Users.Find(u => u.Mail == mail);

            // Kullanıcı bulundu mu?
            if (user != null)
            {
                // Şifre kontrolü
                if (user.Password == password)
                {
                    var activityLog = new ActivityLog() { Status = true,UserId=user.Id};
                    _unitOfWork.ActivityLogs.Add(activityLog);
                    _unitOfWork.Save();
                    // Kullanıcı başarıyla giriş yaptı
                    return LoginResult.Success;
                }
            }

            // Kullanıcı bulunamadı veya şifre yanlış
            return LoginResult.Failure;
        }

        public void LogOut(int id)
        {
            
            var activityLog = new ActivityLog() { Status = false, UserId = id };
            _unitOfWork.ActivityLogs.Add(activityLog);
            _unitOfWork.Save();
        }

        public void Register(User user)
        {
            var existingUser = _unitOfWork.Users.Find(u => u.UserName == user.UserName);

            if (existingUser != null)
            {
                throw new Exception("Bu kullanıcı adı zaten kullanılıyor.");
            }

           
            _unitOfWork.Users.Add(user);
            _unitOfWork.Save();
        }

        public User FindUserByMail(string mail)
        {
            var user = _unitOfWork.Users.Find(x => x.Mail == mail);

            if (user == null)
            {
                // Kullanıcı bulunamadı, isteğe bağlı olarak bir hata işlemi yapabilirsiniz.
                throw new Exception("Kullanıcı bulunamadı.");
            }

            return user;
        }

    }
}
