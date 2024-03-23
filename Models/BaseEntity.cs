using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models;

public class BaseEntity 
{
    [Key]
    public Guid Id { get; init; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }
}