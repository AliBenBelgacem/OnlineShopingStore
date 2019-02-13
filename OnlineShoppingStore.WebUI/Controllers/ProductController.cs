using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.WebUI.Models;
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

        private readonly int pagesize=3;
        public ProductController(IProductRepository repo)
        {
            _repository = repo;
        }
        // GET: Product
        public ActionResult List(int page = 1)
        {
            ProductsListViewModel plVM = new ProductsListViewModel()
            {
                Products = _repository.Products.OrderBy(p => p.ProductId).Skip(page-1* pagesize).Take(pagesize),
                PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = 3, TotalItems = _repository.Products.Count() }
            };
            return View(plVM);
        }
    }
}