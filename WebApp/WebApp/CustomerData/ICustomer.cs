using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.CustomerData
{
    public interface ICustomer
    {
        List<Customer> GetCustomers();

        Customer GetCustomer(int Id);

        Customer AddCustomer(Customer customer);

        Customer UpdateCustomer(Customer customer);


    }
}
