using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataApp.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        Product GetProduct(long id);

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);

        IEnumerable<Product> GetFilteredProducts(string category = null, decimal? price = null);
    }

    public class ProductRepository : IProductRepository
    {
        private DataContext context;

        public ProductRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> Products => this.context.Products.Include(p => p.Supplier).ThenInclude(s => s.Contact).ThenInclude(c => c.Location).ToArray();

        public Product GetProduct(long id)
        {
            var product = this.context.Products.Include(p => p.Supplier).ThenInclude(s => s.Contact).ThenInclude(c => c.Location).FirstOrDefault(p => p.Id == id);
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

        public IEnumerable<Product> GetFilteredProducts(string category = null, decimal? minPrice = null)
        {
            IQueryable<Product> query = this.context.Products;

            if (category != null)
            {
                query = query.Where(p => p.Category == category);
            }

            if (minPrice != null)
            {
                query = query.Where(p => p.Price > minPrice);
            }

            return query.ToList();
        }
    }
}
