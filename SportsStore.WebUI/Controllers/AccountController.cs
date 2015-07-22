using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider authprovider;
        public AccountController(IAuthProvider authprovider)
        {
            this.authprovider = authprovider;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authprovider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    TempData["errosmessage"] = "Incorrect login or password !!!";
                    return View();
                }
            }
            else 
            {
                return View();
            }
        }

        public ActionResult SignOut()
        {
            authprovider.SignOut();
            return RedirectToAction("List", "Product");
        }
	}
}