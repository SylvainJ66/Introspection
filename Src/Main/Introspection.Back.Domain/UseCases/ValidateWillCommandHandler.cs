using Introspection.Back.Domain.Models;

namespace Introspection.Domain.UseCases;

/// <summary>
/// To Validate a will on a specific day
/// </summary>
public class ValidateWillCommandHandler
{
    public Task Handle(Will will, DateTime date)
    {
        if(IsExistsDayWill(will, date))
        {
            Validate(will, date);
            return Task.CompletedTask;
        }

        var dayWill = DayWill.From(date, will);
        dayWill.Status = DayValidationStatus.Validated;
        
        will.DayWills.Add(dayWill);
        
        return Task.CompletedTask;
    }

    private static void Validate(Will will, DateTime date)
    {
        will.DayWills.First(d => d.Date.Date == date.Date).Status = DayValidationStatus.Validated;
    }

    private static bool IsExistsDayWill(Will will, DateTime date)
    {
        return will.DayWills.Any(d => d.Date.Date == date.Date);
    }
}