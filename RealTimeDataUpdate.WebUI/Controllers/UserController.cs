using Microsoft.AspNetCore.Mvc;
using RealTimeDataUpdate.Business.Abstract;
using RealTimeDataUpdate.Business.Concrete;
using System.Security.Claims;

namespace RealTimeDataUpdate.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IActivityLogService _activityLogService;
        private readonly IUserService _userService;

        public UserController(IActivityLogService activityLogService, IUserService userService)
        {
            _activityLogService = activityLogService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var userEmail = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userService.FindUserByMail(userEmail!);
            ViewBag.UserName = user.UserName;
            var activityLogs = _activityLogService.GetAllByUserId(user.Id);
            return View(activityLogs);
        }
    }
}
