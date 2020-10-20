using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using contactsapi.Data.Collections;
namespace contactsapi.Controllers
{
    [ApiController]
    public class ContactController : ControllerBase
    {
        Data.MongoDB mongoDB;
        IMongoCollection<Contact> contactCollection;

        public ContactController(Data.MongoDB mdb) {
            mongoDB = mdb;
            contactCollection = mongoDB.GetCollection<Contact>(typeof(Contact).Name.ToLower());
        }       
    }
}