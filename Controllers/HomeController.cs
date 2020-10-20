using Microsoft.AspNetCore.Mvc;

namespace UserAdminTool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();
    }
}
