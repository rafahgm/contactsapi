using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using contactsapi.Data.Collections;
using contactsapi.Models;

namespace contactsapi.Controllers
{
    [ApiController]
    [Route("[contact]")]
    public class ContactController : ControllerBase
    {
        Data.MongoDB mongoDB;
        IMongoCollection<Contact> contactCollection;

        public ContactController(Data.MongoDB mdb) {
            mongoDB = mdb;
            contactCollection = mongoDB.DB.GetCollection<Contact>(typeof(Contact).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SaveContact([FromBody] ContactDto dto) {
            var contact = new Contact(dto.FirstName, dto.LastName, dto.Phone, dto.Email);
            contactCollection.InsertOne(contact);
            return StatusCode(201, "Contact successfully added.");
        }     

        [HttpGet]
        public ActionResult GetContactS() {
            var contacts = contactCollection.Find(Builders<Contact>.Filter.Empty).ToList();
            return Ok(contacts);
        }       
    }
}