using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShoppingStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EFDbContext eFDbContext;
        public EFProductRepository()
        {
            eFDbContext = new EFDbContext();
        }
        public IEnumerable<Product> Products
        {
            get { return eFDbContext.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                eFDbContext.Products.Add(product);
            }
            else
            {
                Product dbEntry = eFDbContext.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            eFDbContext.SaveChanges();
        }


        public Product DeleteProduct(int productId)
        {
            Product dbEntry = eFDbContext.Products.Find(productId);
            if (dbEntry != null)
            {
                eFDbContext.Products.Remove(dbEntry);
                eFDbContext.SaveChanges();
            }
            return dbEntry;
        }
    }
}
