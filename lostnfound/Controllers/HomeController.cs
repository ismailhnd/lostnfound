using System.Web.Mvc;
using System.Web.Security;
using lostnfound.Models.ViewModel;
using lostnfound.Models.EntityManager;
using lostnfound.Security;
using System.Linq;
namespace lostnfound.Controllers
{
    public class HomeController : Controller
    {
        /********************  Main Views ********************/

        //Homepage View
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            UserManager UM = new UserManager();

            var items = from i in UM.GetItems()
                        orderby i.ItemID
                        select i;

            return View(items);
        }

      
        /********************  POST Request ********************/

        //Login POST Request
        [HttpPost]
        public ActionResult Index(UserLoginView ULV, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                string password = UM.GetUserPassword(ULV.Email);

                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "Your email or password is not valid.");
                else
                {
                    if (ULV.Password.Equals(Utilities.DecryptText(password)))
                    {
                        FormsAuthentication.SetAuthCookie(ULV.Email, false);
                        return RedirectToAction("Dashboard", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Your password is incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form  
            return View(ULV);
        }
 
    }
}