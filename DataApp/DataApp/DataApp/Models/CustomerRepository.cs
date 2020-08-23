using System.Collections.Generic;
using System.Linq;

namespace DataApp.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext context;

        public CustomerRepository(CustomerContext context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return this.context.Customers.ToList();
        }
    }
}
