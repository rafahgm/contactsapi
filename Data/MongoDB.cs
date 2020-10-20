using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using contactsapi.Data.Collections;


namespace contactsapi.Data {
    public class MongoDB {

        public IMongoDatabase DB {get; set;}
        public MongoDB(IConfiguration configuration) {
            try {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(configuration["DataBaseName"]);
                MapClasses();
                
            } catch(Exception ex) {
                throw new MongoException("MONGODB::CONNECTION", ex);
            }
        }

        private void MapClasses() {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);
            if(!BsonClassMap.IsClassMapRegistered(typeof(Contact))) {
                BsonClassMap.RegisterClassMap<Contact>(i => {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}