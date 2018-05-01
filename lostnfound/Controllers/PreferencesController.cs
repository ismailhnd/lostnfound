using System.Web.Mvc;
using System.Web.Security;
using lostnfound.Models.ViewModel;
using lostnfound.Models.EntityManager;
using lostnfound.Security;

namespace lostnfound.Controllers
{
    public class PreferencesController : Controller
    {
        /********************  Main Views ********************/
        //Preferences Main Panel
        [CustomAuthorize("admin")]
        public ActionResult Index()
        {
            return View();
        }

        //Create new User
        [CustomAuthorize("admin")]
        public ActionResult CreateAccount()
        {
            UserManager UM = new UserManager();
            return View(UM.RoleOptions());
        }

        /********************  Partial Views ********************/

        public ActionResult _AddColor()
        {
            return View();
        }

        public ActionResult _AddLocation()
        {
            return View();
        }

        public ActionResult _AddCategory()
        {
            return View();
        }

        /********************  POST Views ********************/

        //User POST Request
        [HttpPost]
        public ActionResult CreateAccount(User user)
        {

            if (ModelState.IsValid)
            {

                UserManager UM = new UserManager();
                if (!UM.IsEmailExist(user.Email))
                {
                    UM.CreateAccount(user);
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Preferences");

                }
                else
                    ModelState.AddModelError("", "Email already taken.");
            }
            return View();
        }


        //Color POST Request
        [HttpPost]
        public ActionResult _AddColor(Settings color)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();

                UM.AddColor(color);

                return RedirectToAction("Index", "Preferences");
            }
            return View();
        }


         [HttpPost]
         public ActionResult _AddLocation(Settings location)
         {
             if (ModelState.IsValid)
             {
                 UserManager UM = new UserManager();

                 UM.AddLocation(location);

                return RedirectToAction("Index", "Preferences");
            }
             return View();
         }

         [HttpPost]
         public ActionResult _AddCategory(Settings category)
         {
             if (ModelState.IsValid)
             {
                 UserManager UM = new UserManager();

                 UM.AddLocation(category);

                return RedirectToAction("Index", "Preferences");
            }
             return View();
         }
    } 
}