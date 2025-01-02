using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models;

[Table("books")]
public class BookModel
{
    [Key]
    [Column("id")]
    public Guid BookId { get; set; }
    [Column("title")]
    public string Title { get; set; }
    [Column("price")]
    public decimal Price { get; set; }
    [Column("archived_at")]
    public DateTime? ArchivedAt { get; set; }
}