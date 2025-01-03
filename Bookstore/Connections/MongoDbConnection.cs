using MongoDB.Driver;

namespace Bookstore.Connections;

public static class MongoDbConnection
{
    public static string ConnectionString { get; set; }

    static MongoDbConnection()
    {
        DotNetEnv.Env.Load("../mongodb.env");
        ConnectionString = Environment.GetEnvironmentVariable("ME_CONFIG_MONGODB_URL");
    }
    
}



