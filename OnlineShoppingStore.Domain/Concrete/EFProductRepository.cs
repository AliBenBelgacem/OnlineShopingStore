using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.Domain.Entities;
using System.Collections.Generic;


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
    }
}
