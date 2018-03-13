using System.Web.Mvc;
using System.Web.Security;
using lostnfound.Models.ViewModel;
using lostnfound.Models.EntityManager;

namespace lostnfound.Controllers
{
    public class AdminController : Controller
    {
        
        public ActionResult Account()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Account(CreateUserView user)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();

                if (!UM.IsEmailExist(user.Email))
                {
                    UM.AddUserAccount(user);
                    FormsAuthentication.SetAuthCookie(user.FirstName, false);
                    return RedirectToAction("Index", "Home");

                }
                else
                    ModelState.AddModelError("", "Email already taken.");
            }
            return View();
        }
    }
}