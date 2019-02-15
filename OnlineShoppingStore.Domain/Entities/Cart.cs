using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            var cart=lineCollection.FirstOrDefault(p => p.Product.ProductId == product.ProductId);
            if (cart == null)
            {
                //GetCart().
                lineCollection.Add(new CartLine{ Product = product, Quantity=1});
            }
            else
            {
                cart.Quantity += quantity;
            }

        }
        public void RemoveLine(Product product, int quantity)
        {
            var cart = lineCollection.FirstOrDefault(p => p.Product.ProductId == product.ProductId);

            cart.Quantity -= quantity;
      
            if (cart.Quantity<=0)
            {
                lineCollection.RemoveAll(r => r.Product.ProductId == product.ProductId);
            }
        }
        public void RemoveLine(Product product)
        { 
                lineCollection.RemoveAll(r => r.Product.ProductId == product.ProductId);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(s => (s.Quantity * s.Product.Price));
        }
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

    }
}
