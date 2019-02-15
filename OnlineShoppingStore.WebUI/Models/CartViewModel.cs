using OnlineShoppingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.WebUI.Models
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public String ReturnUrl { get; set; }
    }
}