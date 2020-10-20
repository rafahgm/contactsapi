using System;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using contactsapi.Data.Collections;
using contactsapi.Models;

namespace contactsapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            return StatusCode(201);
        }     

        [HttpGet]
        public ActionResult GetContacts() {
            var contacts = contactCollection.Find(Builders<Contact>.Filter.Empty).ToList();
            return Ok(contacts);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateContact([FromRoute] string id, [FromBody] ContactDto dto) {
            var contact = new Contact(id, dto.FirstName, dto.LastName, dto.Phone, dto.Email);
            var replaceResult = contactCollection.ReplaceOne(c => c.Id == id, contact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContact([FromRoute] string id) {
            contactCollection.DeleteOne(c => c.Id == id);
            return StatusCode(204);
        }
    }
}