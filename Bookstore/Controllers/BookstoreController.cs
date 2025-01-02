using Bookstore.Contexts;
using Bookstore.Models;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers;


[ApiController]
public class BookstoreController: ControllerBase
{
    private readonly BookstoreService _service;
    
    public BookstoreController(BookstoreContext context)
    {
        _service = new BookstoreService(context);
    }
    
    [HttpGet]
    [Route("/customers")]
    public async Task<ActionResult<List<CustomerModel>>> GetAllCustomers()
    => await _service.GetAllCustomers();
    
    [HttpGet]
    [Route("/customers/{id}")]
    public async Task<ActionResult<CustomerModel>> GetCustomerById(Guid id)
        => await _service.GetCustomerById(id);
    
    [HttpPost]
    [Route("/customers")]
    public async Task<ActionResult<CustomerModel>> CreateCustomer(string name)
        => await _service.CreateCustomer(name);
    
}