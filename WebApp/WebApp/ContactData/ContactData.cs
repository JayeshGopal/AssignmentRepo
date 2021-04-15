using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.ContactData
{
    public class ContactData : IContactRepo
    {
        private ContactContext _contactContext;
        private IDbConnection db;
        public ContactData(ContactContext  contactContext, IConfiguration configuration)
        {
            _contactContext = contactContext;
            db = new SqlConnection(configuration.GetConnectionString("CustomerAppCon"));
        }

        public Contact AddContact(Contact contact)
        {
            _contactContext.Contacts.Add(contact);
            _contactContext.SaveChanges();
            return contact;
        }

        public Contact GetContact(int Id)
        {
            return _contactContext.Contacts.Find(Id);
        }

        public Contact GetContact(string name)
        {
            String query = "SELECT FirstName,LastName,Email,PhoneNo,MobileNo FROM Contacts WHERE FirstName=@Name OR LastName=@Name";
            return db.Query<Contact>(query, new { @Name = name }).SingleOrDefault();
        }

        public List<Contact> GetContacts()
        {
            return _contactContext.Contacts.ToList();
        }

        public Contact UpdateContact(Contact contact)
        {
            String query = "UPDATE Contacts SET FirstName=@FirstName,LastName=@LastName,Email=@Email,PhoneNo=@PhoneNo,MobileNo=@MobileNo"
                + "WHERE ContactId=@ContactId";
            db.Execute(query, contact);
            return db.Query<Contact>("SELECT FirstName,LastName,Email,PhoneNo,MobileNo FROM Contacts WHERE ContactId=@ContactId",new { contact.ContactId}).SingleOrDefault();
        }
    }
}
