namespace ExpenseTracker.Models;

public class Expense : BaseEntity
{
    public required decimal Amount { get; set; }
    public required string Description { get; set; }
    public required DateTime DateSpent { get; set; }
}