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

        /********************  POST Request ********************/

        

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

        //Item POST Request
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

        
    }
}