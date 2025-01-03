using Bookstore.Clients;
using Bookstore.Connections;
using Bookstore.Contexts;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Trace);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<BookstoreContext>(
    dbContextOptions => dbContextOptions.UseMySql(
        MySQLConnection.ConnectionString,
        new MySqlServerVersion(new Version(8, 4, 3))
    )
);
var mongoClient = new OrdersMongoDbClient(MongoDbConnection.ConnectionString);

builder.Services.AddSingleton<IMongoCollection<OrderModel>>(mongoClient.GetCollection<OrderModel>("bookstore", "orders"));
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Bookstore API"));

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<BookstoreContext>();
        db.Database.Migrate();
    }
    
}

app.MapControllers();
app.Run();
