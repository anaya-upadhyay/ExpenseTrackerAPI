namespace ExpenseTracker.Interfaces;

public interface IIncomeService
{
    Task<IEnumerable<Income>> GetAllIncomes();
    Task<Income?> GetIncomeById(Guid id);
    Task<Income> AddIncome(Income income);
    Task<Income?> UpdateIncome(Guid id, Income income);
    Task<bool> DeleteIncome(Guid id);
}