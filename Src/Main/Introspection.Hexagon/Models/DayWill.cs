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

    public DateTime Date { get; }
    public Will Will { get; }
    public DayValidationStatus Status { get; set; }

}