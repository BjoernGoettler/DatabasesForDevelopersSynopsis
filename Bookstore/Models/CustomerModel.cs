using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models;

[Table("customers")]
public class CustomerModel
{
    [Key]
    [Column("id")]
    public Guid CustomerId { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("created_date")]
    public DateTime CreatedDate { get; set; }
}