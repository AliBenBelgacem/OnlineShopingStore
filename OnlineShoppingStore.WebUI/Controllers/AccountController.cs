using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShoppingStore.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        private IProductRepository _repository;
        IAuthentication _authentication;
        public AccountController(IProductRepository repo, IAuthentication auth)
        {
            _repository = repo;
            _authentication = auth;
        }
        public ActionResult Index()
        {
            return View();
        }
      
        [AllowAnonymous]
        public ActionResult Login()


        {

            return View(new LoginViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authentication.Authenticate(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Admin");
        }
    }
}