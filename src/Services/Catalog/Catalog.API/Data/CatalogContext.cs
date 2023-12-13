using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("Databasesettings:Connectionstring"));
            var database = client.GetDatabase(configuration.GetValue<string>("Databasesettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("Databasesettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products {get; }
    }
}
