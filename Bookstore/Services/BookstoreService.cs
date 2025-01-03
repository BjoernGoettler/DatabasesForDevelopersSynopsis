using Bookstore.Contexts;
using Bookstore.Models;
using Bookstore.Repositories;

namespace Bookstore.Services;

public class BookstoreService
{
    private readonly BookstoreRepository _repository;
    
    public BookstoreService(BookstoreContext context)
    {
        _repository = new BookstoreRepository(context);
    }
    
    public async Task<List<CustomerModel>> GetAllCustomers()
        => await _repository.GetAllCustomers();
    
    public async Task<CustomerModel> GetCustomerById(Guid id)
        => await _repository.GetCustomerById(id);
    
    public async Task<CustomerModel> CreateCustomer(string name)
        => await _repository.CreateCustomer(name);
    
    public void DeleteCustomer(Guid id)
        => _repository.DeleteCustomer(id);
    
    public async Task<List<BookModel>> GetAllBooks()
        => await _repository.GetAllBooks();
    
    public async Task<BookModel> GetBookById(Guid id)
        => await _repository.GetBookById(id);
    
    public async Task<BookModel> CreateBook(string title, decimal price)
        => await _repository.CreateBook(title, price);
    
    public async Task<BookModel> ArchiveBook(Guid id)
        => await _repository.ArchiveBook(id);

}