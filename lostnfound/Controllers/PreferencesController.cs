﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lostnfound.Controllers
{
    public class PreferencesController : Controller
    {
        // GET: Preferences
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Advanced()
        {
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }
    }
}