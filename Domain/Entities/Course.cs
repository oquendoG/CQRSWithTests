using Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Course
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [Required]
    [StringLength(100)]
    public string Description { get; set; }
    public decimal Price { get; set; }

    [DateFuture]
    public DateTime PublicationDate { get; set; }
    public DateTime CreationDate { get; set; }
}
