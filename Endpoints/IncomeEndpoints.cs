using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ExpenseTracker.Endpoints;

public static class IncomeEndpoints
{
    public static RouteGroupBuilder MapIncomeEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Income").WithTags(nameof(Income));

        group.MapGet("/", GetIncomes)
             .WithName("GetAllIncomes")
             .WithOpenApi();

        group.MapGet("/{id}", GetIncomeById)
             .WithOpenApi();

        group.MapPost("/", CreateIncome)
        .WithOpenApi();

        group.MapPut("/{id}", UpdateIncome)
        .WithOpenApi();

        group.MapDelete("/{id}", DeleteIncome)
        .WithOpenApi();

        return group;
    }

    private static async Task<IResult> GetIncomes(IIncomeService incomeService) =>
        TypedResults.Ok(await incomeService.GetAllIncomes());

    private static async Task<IResult> GetIncomeById(IIncomeService incomeService, Guid id) =>
        TypedResults.Ok(await incomeService.GetIncomeById(id));

    private static async Task<IResult> CreateIncome(IIncomeService incomeService, Income model)
    {
        var addedIncome = await incomeService.AddIncome(model);
        return TypedResults.Created($"/api/Incomes/{model.Id}", addedIncome);
    }

    private static async Task<IResult> UpdateIncome(Guid id, IIncomeService incomeService, Income model)
    {
        var updatedIncome = await incomeService.UpdateIncome(id, model);
        return TypedResults.Created($"/api/Incomes/{model.Id}", updatedIncome);
    }

    private static async Task<IResult> DeleteIncome(Guid id, IIncomeService incomeService)
    {
        var success = await incomeService.DeleteIncome(id);
        return success ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}