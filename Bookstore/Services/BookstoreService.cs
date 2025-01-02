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

}