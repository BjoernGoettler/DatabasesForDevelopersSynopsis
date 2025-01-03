namespace Bookstore.Connections;

public static class MySQLConnection
{
    public static string ConnectionString { get; set; }
    private static string _databaseHost;
    private static string _databaseName;
    private static string _databaseUser;
    private static string _databasePassword;
    
    
    static MySQLConnection()
    {
        DotNetEnv.Env.Load("../shared.env");
        _databaseHost = "localhost";
        _databaseName = Environment.GetEnvironmentVariable("MYSQL_DATABASE");
        _databaseUser = Environment.GetEnvironmentVariable("MYSQL_USER");
        _databasePassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
        ConnectionString = $"server={_databaseHost};database={_databaseName};user={_databaseUser};password={_databasePassword};";
    }
    
}