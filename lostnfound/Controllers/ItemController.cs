using lostnfound.Models.DB;
using lostnfound.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lostnfound.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            var items = from i in GetItemList()
                        orderby i.FLDate
                        select i;
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Details/5
        public ActionResult Details(int itemID)
        {
            return View();
        }
        
        // GET: Item/Edit/5
        public ActionResult Edit(int itemID)
        {
            return View();
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int itemID, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int itemID)
        {
            return View();
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(int itemID, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        public List<CreateItemView> GetItemList()
        {
            List<CreateItemView> itemList = new List<CreateItemView>();
            using (lostfoundDB db = new lostfoundDB())
            {
                foreach (ITEM i in db.ITEMs)
                {
                    CreateItemView temp = new CreateItemView
                    {
                        ItemID = i.ITEMID,
                        ReporterID = i.REPORTERID,
                        CreatedByID = i.CREATEDBYID,
                        CreatedDate = i.CREATEDDATE,
                        ItemTypeID = i.ITEMTYPEID,
                        StateID = i.STATEID,
                        FLDate = i.FLDATE,
                        CategoryID = i.CATEGORYID,
                        ColorID = i.COLORID,
                        LocationID = i.LOCATIONID,
                        Image = i.IMAGE,
                        Notes = i.NOTES
                    };
                }
            }
            return itemList;
        }

    }
}