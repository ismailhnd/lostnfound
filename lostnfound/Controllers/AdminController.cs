using System.Web.Mvc;
using System.Web.Security;
using lostnfound.Models.ViewModel;
using lostnfound.Models.EntityManager;
using lostnfound.Security;

namespace lostnfound.Controllers
{
    public class AdminController : Controller
    {
        /********************  Main Views ********************/

        //User View
        [CustomAuthorize("admin")]
        public ActionResult Account()
        {

            UserManager UM = new UserManager();
            return View(UM.RoleOptions());
        }

        //Reporter View
        [CustomAuthorize("admin")]
        public ActionResult Reporter()
        {
            return View();
        }

        //Item View
        [CustomAuthorize("admin")]
        public ActionResult Item()
        {
            UserManager UM = new UserManager();
            return View(UM.ItemOptions());
        }

        //Color View
        [CustomAuthorize("admin")]
        public ActionResult Color()
        {
            return View();
        }
                
        //Location View
        [CustomAuthorize("admin")]
        public ActionResult Location()
        {
            return View();
        }


        //Category View
        [CustomAuthorize("admin")]
        public ActionResult Category()
        {
            return View();
        }

        /********************  POST Request ********************/

        //User POST Request
        [HttpPost]
        public ActionResult Account(CreateUserView user)
        {
            
            if (ModelState.IsValid)
            {

                UserManager UM = new UserManager();
                if (!UM.IsEmailExist(user.Email))
                {
                    UM.AddUserAccount(user);
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home");

                }
                else
                    ModelState.AddModelError("", "Email already taken.");
            }
            return View();
        }

        //Reporter POST Request
        [HttpPost]
        public ActionResult Reporter(CreateReporterView user)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();

                UM.AddReporterAccount(user);
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Item(CreateItemView item)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();

                UM.AddItem(item);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Color(CreateColorView color)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                
                UM.AddColor(color);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Location(CreateLocationView location)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();

                UM.AddLocation(location);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Category(CreateCategoryView category)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();

                UM.AddCategory(category);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        
        /********************  Special Functions ********************/

        //SignOut current user
        /*[CustomAuthorize("admin")]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }*/
    }
}