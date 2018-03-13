
using System.Web.Mvc;

namespace lostnfound.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.LeftString = "";
            ViewBag.RightString = "";

            return View();
        }
    }
}