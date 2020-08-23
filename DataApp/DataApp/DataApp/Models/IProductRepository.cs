using System.Collections.Generic;

namespace DataApp.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        Product GetProduct(long id);

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);
    }
}
