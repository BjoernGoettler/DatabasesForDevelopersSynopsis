using System.Text.Json.Serialization;
using MongoDB.Bson;

namespace Bookstore.Models;

public class OrderCreateReturnModel
{
    public string Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<BookModelDto> Books { get; set; } = new List<BookModelDto>();
}