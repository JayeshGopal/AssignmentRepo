﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ContactData;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepo _repo;

        public ContactController(IContactRepo contactRepo)
        {
            _repo = contactRepo;
        }

        [HttpGet]
        public ActionResult<List<Contact>> GetContacts()
        {
            return _repo.GetContacts();
        }

        [HttpGet]
        [Route("id/{id}")]
        public IActionResult GetContact(int Id)
        {
            var contact =  _repo.GetContact(Id);
            if (contact != null) {
                return Ok(contact);
            }
            return NotFound("No Matching Contact Found");
        }

        [HttpGet]
        [Route("name/{name}")]
        public IActionResult GetContact(String name)
        {
            var contact = _repo.GetContact(name);
            if (contact != null)
            {
                return Ok(contact);
            }
            return NotFound("No Matching Contact Found");
        }

        [HttpPost]
        public IActionResult AddContact([FromBody] Contact contact)
        {
            var newContact = _repo.AddContact(contact);
            if (newContact != null) {
                return Ok("Contact added successfully");
            }
            return NotFound("Failed to add Contact");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateContact(int id,[FromBody] Contact contact)
        {
            var existContact = _repo.GetContact(id);
            if (existContact != null) {
                contact.ContactId = existContact.ContactId;
                return Ok(_repo.UpdateContact(contact));
            }
            return NotFound("Failed To update contact");
        }
    }
}
