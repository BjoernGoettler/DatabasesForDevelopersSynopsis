using Bookstore.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Bookstore.Repositories;

public class OrderRepository
{
    private readonly IMongoCollection<OrderModel> _collection;
    
    public OrderRepository(IMongoCollection<OrderModel> collection)
        => _collection = collection;
    
    public async Task<List<OrderModel>> GetAllOrders()
        => await _collection.Find(order => true).ToListAsync();
    
    public async Task<OrderModel> GetOrderById(ObjectId id)
        => await _collection.Find(order => order.Id == id).FirstOrDefaultAsync();

    public async Task<OrderModel> CreateOrder(string customerName)
    {
        var order = new OrderModel
        {
            Id = ObjectId.GenerateNewId(),
            CustomerName = customerName,
            Books = new List<BookModelDto>()
        };
        
        await _collection.InsertOneAsync(order);
        
        return order;
    }

    public async Task<OrderModel> AppendBookToOrder(ObjectId orderId, BookModelDto book)
    {
        var order = await GetOrderById(orderId);
        order.Books.Add(book);
        
        await _collection.ReplaceOneAsync(o => o.Id == orderId, order);
        
        return order;
    }
}