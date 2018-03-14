
using System.Web.Mvc;

namespace lostnfound.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.LeftString = "Test One";
            ViewBag.RightString = "Test Two";
            ViewBag.LeftStringLink = "#";
            ViewBag.RightStringLink = "#";

            return View();
        }
    }
}