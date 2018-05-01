using lostnfound.Models.EntityManager;
using lostnfound.Models.ViewModel;
using lostnfound.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            UserManager UM = new UserManager();
            return View(UM.ItemOptions());
        }

        // GET: Item (Edit Item)
        public ActionResult Edit()
        {
            return View();
        }

        // GET: Item (Item Details)
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UserManager UM = new UserManager();
            Item item = UM.getItem(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Item (Delete Item)
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UserManager UM = new UserManager();
            Item item = UM.getItem(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }


        //Temperor View: Reporter
        [CustomAuthorize("admin")]
        public ActionResult Reporter()
        {
            return View();
        }

        /*############################################### POST Views ###############################################*/


        // POST: Item (Create Item)
        [HttpPost]
        public ActionResult Create(Item item)
        {
            UserManager UM = new UserManager();

            UM.CreateItem(item);
            return View(item);
        }

        // POST: Item (Delete Item)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            UserManager UM = new UserManager();
            UM.DeleteItem(id);
            return RedirectToAction("Index");
        }
    }
}