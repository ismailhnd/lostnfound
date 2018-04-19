using System.Web.Mvc;
using System.Web.Security;
using lostnfound.Models.ViewModel;
using lostnfound.Models.EntityManager;
using lostnfound.Security;
using System.Web;
using System.Web.Configuration;
using System;

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

        //Unauthorized Access
        public ActionResult Unauthorized()
        {
            return View();
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
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                else
                {
                    if (ULV.Password.Equals(password))
                    {
                        FormsAuthentication.SetAuthCookie(ULV.Email, false);
                        return RedirectToAction("Reporter", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form  
            return View(ULV);
        }



        /********************  Special Functions ********************/

        //SignOut current user
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        

    }
}