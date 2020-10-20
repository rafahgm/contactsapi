using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace contactsapi.Data.Collections
{
    public class Contact
    {
        public Contact(String firstName, String lastName, String phone, String email) {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.Email = email;
        }

        public Contact(String id, String firstName, String lastName, String phone, String email) {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Phone = phone;
            this.Email = email;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id {get; set;}
         public String FirstName {get; set;}
         public String LastName {get; set;}
         public String Phone {get; set;}
         public String Email {get; set;}
    }

   

}