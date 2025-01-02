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

}