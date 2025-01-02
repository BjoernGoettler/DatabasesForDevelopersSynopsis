using Bookstore.Contexts;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Repositories;

public class BookstoreRepository
{
    private readonly BookstoreContext _context;
    
    public BookstoreRepository(BookstoreContext context)
    {
        _context = context;
    }

    public async Task<List<CustomerModel>> GetAllCustomers()
        => await _context.Customers.ToListAsync();
    
    public async Task<CustomerModel> GetCustomerById(Guid id)
        => await _context.Customers.FindAsync(id);

    public async Task<CustomerModel> CreateCustomer(string name)
    {
        var customer = new CustomerModel
        {
            CustomerId = Guid.NewGuid(),
            Name = name,
            CreatedDate = DateTime.UtcNow
        };
        
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        
        return customer;
    }
    
    /// <summary>
    /// Lists all books where ArchivedAt is not set, or in the future
    /// </summary>
    /// <returns></returns>
    public async Task<List<BookModel>> GetAllBooks()
        => await _context.Books
            .Where(book => book.ArchivedAt == null || book.ArchivedAt > DateTime.UtcNow)
            .ToListAsync();
    
    public async Task<BookModel> GetBookById(Guid id)
        => await _context.Books.FindAsync(id);

    public async Task<BookModel> CreateBook(string title, decimal price)
    {
        var book = new BookModel
        {
            BookId = Guid.NewGuid(),
            Title = title,
            Price = price
        };
        
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        
        return book;
    }
    
    public async Task<BookModel> ArchiveBook(Guid id)
    {
        var book = await _context.Books.FindAsync(id);
        book.ArchivedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        
        return book;
    }

}