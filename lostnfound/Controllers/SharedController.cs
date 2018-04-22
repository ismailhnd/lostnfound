using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lostnfound.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        
        public ActionResult _Unauthorized()
        {
            return View();
        }
    }
}