using Bookstore.Connections;
using Bookstore.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<BookstoreContext>(
    dbContextOptions => dbContextOptions.UseMySql(
        MySQLConnection.ConnectionString,
        new MySqlServerVersion(new Version(8, 0, 27))
    )
);
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

app.Run();
