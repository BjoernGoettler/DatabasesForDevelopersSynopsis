using Bookstore.Contexts;
using Bookstore.Models;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Bookstore.Controllers;

[ApiController]
public class BookstoreController: ControllerBase
{
    private readonly BookstoreService _bookstoreService;
    private readonly OrderService _orderService;
    
    public BookstoreController(BookstoreContext context, IMongoCollection<OrderModel> collection)
    {
        _bookstoreService = new BookstoreService(context);
        _orderService = new OrderService(collection);
    }
    
    [HttpGet]
    [Route("/customers")]
    public async Task<ActionResult<List<CustomerModel>>> GetAllCustomers()
    => await _bookstoreService.GetAllCustomers();
    
    [HttpGet]
    [Route("/customers/{id}")]
    public async Task<ActionResult<CustomerModel>> GetCustomerById(Guid id)
        => await _bookstoreService.GetCustomerById(id);
    
    [HttpPost]
    [Route("/customers")]
    public async Task<ActionResult<CustomerModel>> CreateCustomer(string name)
        => await _bookstoreService.CreateCustomer(name);
    
    [HttpGet]
    [Route("/books")]
    public async Task<ActionResult<List<BookModel>>> GetAllBooks()
        => await _bookstoreService.GetAllBooks();
    
    [HttpGet]
    [Route("/books/{id}")]
    public async Task<ActionResult<BookModel>> GetBookById(Guid id)
        => await _bookstoreService.GetBookById(id);
    
    [HttpPost]
    [Route("/books")]
    public async Task<ActionResult<BookModel>> CreateBook(string title, decimal price)
        => await _bookstoreService.CreateBook(title, price);
    
    [HttpDelete]
    [Route("/books/{id}")]
    public async Task<ActionResult<BookModel>> ArchiveBook(Guid id)
        => await _bookstoreService.ArchiveBook(id);
    
    [HttpPost]
    [Route("/orders")]
    public async Task<ActionResult<OrderCreateReturnModel>> CreateOrder([FromBody] string customerName)
        => await _orderService.CreateOrder(customerName);
    
    [HttpGet]
    [Route("/orders")]
    public async Task<ActionResult<List<OrderCreateReturnModel>>> GetAllOrders()
        => await _orderService.GetAllOrders();
    
    [HttpGet]
    [Route("/orders/{id}")]
    public async Task<ActionResult<OrderCreateReturnModel>> GetOrderById(ObjectId id)
        => await _orderService.GetOrderById(id);
    
    [HttpPost]
    [Route("/orders/{id}/books")]
    public async Task<ActionResult<OrderCreateReturnModel>> AppendBookToOrder(string id, [FromBody] BookModelDto book)
        => await _orderService.AppendBookToOrder(ObjectId.Parse(id), book);

    [HttpDelete]
    [Route("/gdpr/customers/{customerId}")]
    public async  Task<ActionResult> DeleteCustomersOrders(string customerId)
    {
        var customer = await _bookstoreService.GetCustomerById(Guid.Parse(customerId));
        _orderService.DeleteCustomersOrders(customer.Name);
        return Ok();
    }
}