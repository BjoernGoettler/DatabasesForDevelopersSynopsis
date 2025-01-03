using System.Text.Json.Serialization;

namespace Bookstore.Models;

public class CustomerModelDto
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
}