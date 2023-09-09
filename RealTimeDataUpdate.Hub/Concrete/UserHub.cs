using Microsoft.AspNetCore.SignalR;
using RealTimeDataUpdate.Business.Abstract;
using System.Threading.Tasks;

namespace RealTimeDataUpdate.Hub.Concrete
{
    public class UserHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IUserService _userService;

        public UserHub(IUserService userService)
        {
            _userService = userService;
        }

        // Kullanıcı girişi olayı
        public async Task UserLoggedIn(string mail)
        {
            var user = _userService.FindUserByMail(mail);
            
            // Kullanıcı girişi olayını diğer istemcilere iletiyoruz
            await Clients.All.SendAsync("UserLoggedIn", user.UserName);
        }

        // Kullanıcı çıkışı olayı
        public async Task UserLoggedOut(string userName)
        {
            // Kullanıcı çıkışı olayını diğer istemcilere iletiyoruz
            await Clients.All.SendAsync("UserLoggedOut", userName);
        }
    }
}
