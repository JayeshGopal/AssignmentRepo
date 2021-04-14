using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApp.CustomerData;
using WebApp.Models;

namespace WebApp.CustomerData
{
    public class DapperCustomerData : ICustomer
    {
        private IDbConnection db;

        public DapperCustomerData(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("CustomerAppCon"));
        }
        public Customer AddCustomer(Customer customer)
        {
            String query = "INSERT INTO Customers VALUES(@FirstName,@LastName,@Email,@ContactNo)";
            var afftedRows = db.Query<Customer>(query, customer);
            Console.WriteLine($"Data Inserted = {afftedRows}");
            String query2 = "SELECT * FROM Customers WHERE FirstName = @FirstName";
            return db.Query<Customer>(query2, new { customer.FirstName }).Single();
        }

        public Customer GetCustomer(int Id)
        {
            String query = "SELECT * FROM Customers WHERE Id = @Id";
            return db.Query<Customer>(query,new {@Id = Id }).Single();
        }

        public List<Customer> GetCustomers()
        {
            String query = "SELECT * FROM Customers";
            return db.Query<Customer>(query).ToList();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            String query = "UPDATE Customers SET FirstName=@FirstName, LastName=@LastName,Email=@Email,ContactNo=@ContactNo WHERE Id=@Id";
            db.Execute(query, customer);

            String query2 = "SELECT * FROM Customers WHERE Id = @Id";
            return db.Query<Customer>(query2, new { customer.Id }).Single();
        }
    }
}
