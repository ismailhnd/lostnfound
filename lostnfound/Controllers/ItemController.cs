using lostnfound.Models.EntityManager;
using lostnfound.Models.ViewModel;
using lostnfound.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace lostnfound.Controllers
{
    public class ItemController : Controller
    {
        /*############################################### GET Views ###############################################*/
        // GET: Item (Create Item)
        public ActionResult Create()
        {
            return View();
        }

        // GET: Item (Edit Item)
        public ActionResult Edit()
        {
            return View();
        }

        // GET: Item (Item Details)
        public ActionResult Details()
        {
            return View();
        }

        // GET: Item (Delete Item)
        public ActionResult Delete()
        {
            return View();
        }


        //Temperor View: Reporter
        [CustomAuthorize("admin")]
        public ActionResult Reporter()
        {
            return View();
        }

        /*############################################### POST Views ###############################################*/
        [HttpPost]
        public ActionResult Reporter(Reporter user)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();

                UM.CreateReporter(user);
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}