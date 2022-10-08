using Introspection.Unit.Hexagon.UseCases;

namespace Introspection.Unit.Hexagon.Models;

public class DayIntrospection
{
    public string Name { get; init; }
    public DateTime Day { get; init; }
    public StatusDayValidation Status { get; private set; } = StatusDayValidation.Missed;
    
    public DayIntrospection(DateTime day, string name)
    {
        Name = name;
        Day = day;
    }
    
    public void Validate(StatusDayValidation status)
    {
        Status = status;
    }
}