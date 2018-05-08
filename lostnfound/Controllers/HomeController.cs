using System.Web.Mvc;
using System.Web.Security;
using lostnfound.Models.ViewModel;
using lostnfound.Models.EntityManager;
using lostnfound.Security;
using System.Linq;
using System.Collections.Generic;

namespace lostnfound.Controllers
{
    public class HomeController : Controller
    {
        /*############################################### GET Views ###############################################*/

        //GET: Hompage
        public ActionResult Index()
        {
            return View();
        }

        //GET: Dashboard
        public ActionResult Dashboard(string searchby, string search)
        {
            UserManager UM = new UserManager();

            var items = from i in UM.GetItems()
                        orderby i.ItemID
                        select i;

            
            if (searchby != null )
            {
                return View(UM.Search(searchby,search,items));
            }
            else
            {
                return View(items);
            }
            
        }

        /*############################################### POST Views ###############################################*/

        //POST: Homepage (Login)
        [HttpPost]
        public ActionResult Index(LoginModel ULV, string returnUrl)
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
            return View(ULV);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}