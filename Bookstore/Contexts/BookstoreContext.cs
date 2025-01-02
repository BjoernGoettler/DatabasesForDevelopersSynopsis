using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Contexts;

public class BookstoreContext: DbContext
{
    public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
    {
    }
    
    public DbSet<CustomerModel> Customers { get; set; }
    public DbSet<BookModel> Books { get; set; }
    
}