using OnlineShoppingStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.WebUI.Controllers
{
    public class MenuController : Controller
    {
        private IProductRepository _repository;
     
        public MenuController(IProductRepository repo)
        {
            _repository = repo;
        }
        // GET: Menu
        public PartialViewResult Menu(string category)
        {
            ViewBag.SelectedCategory = category;

            return PartialView(_repository.Products.Select(sel=>sel.Category.Trim()).Distinct());
        }
    }
}