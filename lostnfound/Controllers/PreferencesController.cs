using System.Web.Mvc;
using System.Web.Security;
using lostnfound.Models.ViewModel;
using lostnfound.Models.EntityManager;
using lostnfound.Security;

namespace lostnfound.Controllers
{
    public class PreferencesController : Controller
    {
        /*############################################### GET Views ###############################################*/
        
        //GET: Index (Settings)
        [CustomAuthorize("admin")]
        public ActionResult Index()
        {
            return View();
        }

        //GET: Create User
        [CustomAuthorize("admin")]
        public ActionResult CreateUser()
        {
            UserManager UM = new UserManager();
            return View(UM.RoleOptions());
        }

        //GET: Add Color
        public ActionResult AddColor()
        {
            return View();
        }

        //GET: Add Category
        public ActionResult AddCategory()
        {
            return View();
        }

        //GET: Add Location
        public ActionResult AddLocation()
        {
            return View();
        }

        //GET: Add Role
        public ActionResult AddRole()
        {
            return View();
        }
        //GET: Add State
        public ActionResult AddState()
        {
            return View();
        }

        //GET: Add Type
        public ActionResult AddType()
        {
            return View();
        }

        /*############################################### POST Views ###############################################*/


        //POST: Create User
        [HttpPost]
        public ActionResult CreateUser(User user)
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


        //POST: Add Color
        [HttpPost]
        public ActionResult AddColor(Settings color)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();

                UM.AddColor(color);

                return RedirectToAction("Index", "Preferences");
            }
            return View();
        }

        //POST: Add Location
        [HttpPost]
        public ActionResult AddLocation(Settings location)
         {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();

                UM.AddLocation(location);

            return RedirectToAction("Index", "Preferences");
            }
            return View();
         }

        //POST: Add Category
        [HttpPost]
        public ActionResult AddCategory(Settings category)
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