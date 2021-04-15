using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.ContactData
{
    interface IContactRepo
    {
        List<Contact> GetContacts();
        Contact GetContact(int Id);
        Contact GetContact(String name);
        Contact AddContact(Contact contact);
        Contact UpdateContact(Contact contact);

    }
}
