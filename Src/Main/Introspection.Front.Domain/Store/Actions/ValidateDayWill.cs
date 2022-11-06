using Introspection.Front.Domain.Models;

namespace Introspection.Front.Domain.Store.Actions;

public class ValidateDayWill
{
    public DayWill DayWill { get; }
    public DayValidationStatus Status { get; }

    public ValidateDayWill(DayWill dayWill, DayValidationStatus status)
    {
        DayWill = dayWill;
        Status = status;
    }
}