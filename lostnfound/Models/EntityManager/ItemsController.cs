using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lostnfound.Models.DB;

namespace lostnfound.Models.EntityManager
{
    public class ItemsController : Controller
    {
        // GET: Items
        public List<ITEM> GetItems()
        {
            using (lostfoundDB db = new lostfoundDB())
            {
                var Item = db.ITEMs.Select(o => new ITEM
                {
                    ITEMID = o.ITEMID,
                    ITEMSTATEs = o.ITEMSTATEs,
                    ITEMTYPE = o.ITEMTYPE,
                    ITEMTYPEID = o.ITEMTYPEID
                }).ToList();
            }
        }
    }
}