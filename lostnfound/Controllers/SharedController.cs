using System.Web.Mvc;
using System.Web.Security;

namespace lostnfound.Controllers
{
    public class SharedController : Controller
    {
        /********************  Main Views ********************/

        public ActionResult _Unauthorized()
        {
            return View();
        }


        /********************  Special Action ********************/

        //SignOut current user
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}