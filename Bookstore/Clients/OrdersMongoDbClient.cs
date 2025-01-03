using MongoDB.Driver;

namespace Bookstore.Clients;

public class OrdersMongoDbClient
{
    
    private readonly string _connectionString;
    private IMongoClient _client;

    public OrdersMongoDbClient(string connectionString)
    {
        _connectionString = connectionString;
        Connect();
    }
    private void Connect()
    {
        _client = new MongoDB.Driver.MongoClient(_connectionString);
    }

    public IMongoCollection<T>GetCollection<T>(string database, string collectionName)
    {
        return _client.GetDatabase(database).GetCollection<T>(collectionName);
    }
}