using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApp.Models;

namespace WebApp.CustomerData
{
    public class DapperEntityCustomerData : ICustomer
    {
        private CustomerContext _customerContext;
        private IDbConnection db;

        public DapperEntityCustomerData(CustomerContext customerContext, IConfiguration configuration)
        {
            _customerContext = customerContext;
            db = new SqlConnection(configuration.GetConnectionString("CustomerAppCon"));
        }
        public Customer AddCustomer(Customer customer)
        {
            _customerContext.Customers.Add(customer);
            _customerContext.SaveChanges();

            return customer;
        }

        public Customer GetCustomer(int Id)
        {
            String query = "SELECT * FROM Customers WHERE Id = @Id";
            return db.Query<Customer>(query, new { @Id = Id }).SingleOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            String query = "SELECT * FROM Customers";
            return db.Query<Customer>(query).ToList();
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
