using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataApp.Models
{
    public interface ISupplierRepository
    {
        Supplier Get(long id);

        IEnumerable<Supplier> GetAll();

        void Create(Supplier supplier);

        void Update(Supplier supplier);

        void Delete(long id);
    }

    public class SupplierRepository : ISupplierRepository
    {
        private DataContext context;

        public SupplierRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return this.context.Suppliers.Include(s => s.Products).ToList();
        }

        public Supplier Get(long id)
        {
            var supplier = this.context.Suppliers.Include(s => s.Products).FirstOrDefault(s => s.Id == id);
            return supplier;
        }

        public void Create(Supplier supplier)
        {
            this.context.Suppliers.Add(supplier);
            this.context.SaveChanges();
        }

        public void Update(Supplier supplier)
        {
            this.context.Suppliers.Update(supplier);
            this.context.SaveChanges();
        }

        public void Delete(long id)
        {
            this.context.Suppliers.Remove(this.Get(id));
            this.context.SaveChanges();
        }
    }
}
