namespace ExpenseTracker.Models;

public class Income : BaseEntity
{
    public required decimal Amount { get; set; }
    public required DateTime ReceivedDate { get; set; } = DateTime.UtcNow;
}
