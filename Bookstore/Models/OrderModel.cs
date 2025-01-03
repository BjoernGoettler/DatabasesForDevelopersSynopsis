using System.Text.Json.Serialization;
using MongoDB.Bson;

namespace Bookstore.Models;

public class OrderModel
{ 
    public BsonObjectId Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public List<BookModelDto> Books { get; set; } = new List<BookModelDto>();
}