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
        public ActionResult Color()
        {
            return View();
        }

        [CustomAuthorize("admin")]
        //GET: Add Category
        public ActionResult Category()
        {
            return View();
        }

        [CustomAuthorize("admin")]
        //GET: Add Location
        public ActionResult Location()
        {
            return View();
        }

        [CustomAuthorize("admin")]
        //GET: Add Role
        public ActionResult Role()
        {
            return View();
        }

        [CustomAuthorize("admin")]
        //GET: Add State
        public ActionResult State()
        {
            return View();
        }

        [CustomAuthorize("admin")]
        //GET: Add Type
        public ActionResult Type()
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
        public ActionResult Color(Color color)
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
        public ActionResult Location(Location location)
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
        public ActionResult Category(Category category)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();

                UM.AddCategory(category);

            return RedirectToAction("Index", "Preferences");
        }
            return View();
        }

        //POST: Add State
        [HttpPost]
        public ActionResult State(State state)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();

                UM.AddState(state);

                return RedirectToAction("Index", "Preferences");
            }
            return View();

        }

        //POST: Add Type
        [HttpPost]
        public ActionResult Type(ItemType type)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();

                UM.AddType(type);

                return RedirectToAction("Index", "Preferences");
            }
            return View();
        }

        //POST: Add Role
        [HttpPost]
        public ActionResult Role(Role role)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();

                UM.AddRole(role);

                return RedirectToAction("Index", "Preferences");
            }
            return View();
        }
    } 
}