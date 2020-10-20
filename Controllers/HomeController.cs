using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserAdminTool.Models;

namespace UserAdminTool.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<AppUser> userManager;

        public HomeController(UserManager<AppUser> usrMgr)
        {
            userManager = usrMgr;
        }

        public ViewResult Index() => View(userManager.Users);
        public ViewResult Create() => View();
    }
}
