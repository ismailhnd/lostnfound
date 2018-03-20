﻿using System.Web.Mvc;
using System.Web.Security;
using lostnfound.Models.ViewModel;
using lostnfound.Models.EntityManager;

namespace lostnfound.Controllers
{
    public class AdminController : Controller
    {
        /********************  Main Views ********************/

        //User View
        public ActionResult Account()
        {
            return View();
        }

        //Reporter View
        public ActionResult Reporter()
        {
            return View();
        }


        /********************  POST Request ********************/

        //User POST Request
        [Authorize]
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
        [Authorize]
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



        /********************  Special Functions ********************/

        //SignOut current user
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}