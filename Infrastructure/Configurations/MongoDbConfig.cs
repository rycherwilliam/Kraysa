using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Configurations
{
    public class MongoDbConfig
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public IMongoClient Client { get; private set; }

        public MongoDbConfig(IConfiguration configuration)
        {
            ConnectionString = configuration["MongoDbSettings:ConnectionString"];
            DatabaseName = configuration["MongoDbSettings:DatabaseName"];
            Client = new MongoClient(ConnectionString);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            if (string.IsNullOrEmpty(DatabaseName))
            {
                throw new ArgumentNullException(nameof(DatabaseName));
            }
            return Client.GetDatabase(DatabaseName).GetCollection<T>(collectionName);
        }
    }
}