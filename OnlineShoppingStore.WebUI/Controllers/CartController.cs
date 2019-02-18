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
        private IOrderProcessor _order; 

        public CartController(IProductRepository repo,IOrderProcessor order)
        {
            _repository = repo;
            _order = order;
        }

        public ActionResult index(Cart cart,int productId, string returnUrl)
        {
            CartViewModel cartVM = new CartViewModel { Cart = cart, ReturnUrl = returnUrl };

            return View(cartVM);
        }

        // GET: Cart
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("index", new {  productId, returnUrl });
        }

        // GET: Cart
        public RedirectToRouteResult RemoveFromCart(Cart cart,int productId, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("index", new { productId, returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() ==0)
            {
                ModelState.AddModelError("", "Sorry Your Cart Is Empty");
            }
            if (ModelState.IsValid == true)
            {
                _order.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(new ShippingDetails());
            }
        }

    }
}