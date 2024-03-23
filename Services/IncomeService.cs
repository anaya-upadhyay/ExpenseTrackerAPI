namespace ExpenseTracker.Services;

public class IncomeService : IIncomeService
{
    private readonly ExpensesDbContext _context;

    public IncomeService(ExpensesDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Income>> GetAllIncomes() => 
        await _context.Incomes.ToListAsync();

    public async Task<Income?> GetIncomeById(Guid id) => 
        await _context.Incomes.FindAsync(id);

    public async Task<Income> AddIncome(Income income)
    {
        _context.Incomes.Add(income);
        await _context.SaveChangesAsync();

        return income;
    }

    public async Task<Income?> UpdateIncome(Guid id, Income income)
    {
        var updateableIncome = await _context.Incomes.FindAsync(id);

        if (updateableIncome is null) return null;

        updateableIncome.Amount = income.Amount;
        updateableIncome.ModifiedDate = DateTime.Now;

        await _context.SaveChangesAsync();

        return updateableIncome;
    }

    public async Task<bool> DeleteIncome(Guid id)
    {
        var income = _context.Incomes.FirstOrDefault(i => i.Id == id)!;

        if (income is null) return false;

        _context.Incomes.Remove(income);
        await _context.SaveChangesAsync();

        return true;
    }

}
