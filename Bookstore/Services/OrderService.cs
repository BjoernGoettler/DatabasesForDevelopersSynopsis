using Bookstore.Models;
using Bookstore.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Bookstore.Services;

public class OrderService
{
    private readonly OrderRepository _repository;
    
    public OrderService(IMongoCollection<OrderModel> collection)
        => _repository = new OrderRepository(collection);

    public async Task<OrderCreateReturnModel> CreateOrder(string customerName)
    {
        var order = await _repository.CreateOrder(customerName);
        return new OrderCreateReturnModel
        {
            Id = order.Id.ToString(),
            CustomerName = order.CustomerName,
            Books = order.Books
        };
    }

    public async Task<List<OrderCreateReturnModel>> GetAllOrders()
    {
        var orders = await _repository.GetAllOrders();
        return orders.Select(order => new OrderCreateReturnModel
        {
            Id = order.Id.ToString(),
            CustomerName = order.CustomerName,
            Books = order.Books
        }).ToList();
    }

    public async Task<OrderCreateReturnModel> GetOrderById(ObjectId orderId)
    {
        var order = await _repository.GetOrderById(orderId);
        return new OrderCreateReturnModel
        {
            Id = order.Id.ToString(),
            CustomerName = order.CustomerName,
            Books = order.Books
        };
    }

    public async Task<OrderCreateReturnModel> AppendBookToOrder(ObjectId orderId, BookModelDto book)
    {
        var order = await _repository.AppendBookToOrder(orderId, book);
        return new OrderCreateReturnModel
        {
            Id = order.Id.ToString(),
            CustomerName = order.CustomerName,
            Books = order.Books
        };
    }
    public void DeleteCustomersOrders(string customerName)
        => _repository.DeleteCustomersOrders(customerName);
}