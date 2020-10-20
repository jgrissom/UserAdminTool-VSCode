using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserAdminTool.Models;
using System.Threading.Tasks;

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
        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
