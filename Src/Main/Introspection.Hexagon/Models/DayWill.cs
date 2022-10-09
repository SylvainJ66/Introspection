namespace Introspection.Hexagon.Models;

/// <summary>
/// Will for a specific day
/// </summary>
public class DayWill
{
    public DayWill(DateTime date, Will will)
    {
        Date = date;
        Will = will;
    }

    public DateTime Date { get; init; }
    public Will Will { get; init; }
    public DayValidationStatus Status { get; set; }

}