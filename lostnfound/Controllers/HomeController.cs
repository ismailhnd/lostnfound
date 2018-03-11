
using System.Web.Mvc;

namespace lostnfound.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.LeftString = "Left String";
            ViewBag.RightString = "Right String";

            return View();
        }
    }
}