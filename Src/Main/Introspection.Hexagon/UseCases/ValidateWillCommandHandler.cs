using Introspection.Hexagon.Models;

namespace Introspection.Hexagon.UseCases;

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

        var dayWill = new DayWill(date, will)
        {
            Status = DayValidationStatus.Validated
        };
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