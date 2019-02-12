using OnlineShoppingStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repo)
        {
            _repository = repo;
        }
        // GET: Product
        public ActionResult List()
        {
            return View(_repository.Products);
        }
    }
}