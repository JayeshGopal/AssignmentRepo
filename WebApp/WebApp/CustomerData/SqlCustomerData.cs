using System.Collections.Generic;
using System.Linq;
using WebApp.Models;

namespace WebApp.CustomerData
{
    public class SqlCustomerData : ICustomer
    {
        private CustomerContext _customerContext;

        public SqlCustomerData(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
        public Customer AddCustomer(Customer customer)
        {
            _customerContext.Customers.Add(customer);
            _customerContext.SaveChanges();

            return customer;
        }

        public Customer GetCustomer(int Id)
        {
            var customer = _customerContext.Customers.Find(Id);
            return customer;
        }

        public List<Customer> GetCustomers()
        {
            return _customerContext.Customers.ToList();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var existingCustomer = _customerContext.Customers.Find(customer.Id);

            if(existingCustomer != null) {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.ContactNo = customer.ContactNo;
                _customerContext.Customers.Update(existingCustomer);
                _customerContext.SaveChanges();
            }
            return customer;
        }
    }
}
