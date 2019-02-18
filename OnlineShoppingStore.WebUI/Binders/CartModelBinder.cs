using OnlineShoppingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.WebUI.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string KeySession = "Cart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = null;
            if (controllerContext.HttpContext.Session!=null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[KeySession];
               
            }
         
            if (cart==null)
            {
                cart = new Cart();

                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[KeySession] = cart;
            }

            return cart; 
            
        }
    }
}