using System.Collections.Generic;
using System.Linq;

namespace DataApp.Models
{
    public class ProductRepository : IProductRepository
    {
        private DataContext context;

        public ProductRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> Products => this.context.Products.ToArray();

        public Product GetProduct(long id)
        {
            var product = this.context.Products.Find(id);
            return product;
        }

        public void CreateProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = this.GetProduct(product.Id);
            existingProduct.Name = product.Name;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;
            this.context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            this.context.Products.Remove(product);
            this.context.SaveChanges();
        }
    }
}
