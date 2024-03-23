namespace ExpenseTracker;

public class ExpensesDbContext : DbContext
{
    public ExpensesDbContext(DbContextOptions options) : base(options)
    {
    }

    #region DbSets

    public DbSet<Income> Incomes { get; set; }
    public DbSet<Expense> Expenses { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
