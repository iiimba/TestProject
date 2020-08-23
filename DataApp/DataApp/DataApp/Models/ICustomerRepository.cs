using System.Collections.Generic;

namespace DataApp.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
    }
}
