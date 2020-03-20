using MyMechanic.Core;
using System.Web.Mvc;

namespace MyMechanic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}