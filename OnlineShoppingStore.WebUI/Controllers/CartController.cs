using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.Domain.Entities;
using OnlineShoppingStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repository;

        public CartController(IProductRepository repo)
        {
            _repository = repo;
        }

        public ActionResult index(int productId, string returnUrl)
        {
            CartViewModel cartVM = new CartViewModel { Cart = GetCart(), ReturnUrl = returnUrl };

            return View(cartVM);
        }

        // GET: Cart
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("index", new {  productId, returnUrl });
        }

        // GET: Cart
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                GetCart().RemoveLine(product);
            }

            return RedirectToAction("index", new { productId, returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];

            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
    }
}