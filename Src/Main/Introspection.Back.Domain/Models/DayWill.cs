namespace Introspection.Back.Domain.Models;

/// <summary>
/// Will for a specific day
/// </summary>
public class DayWill
{
    private DayWill(DateTime date, Will will)
    {
        Id = Guid.NewGuid();
        Date = date;
        Will = will;
    }

    public Guid Id { get; }
    public DateTime Date { get; }
    public Will Will { get; }
    public DayValidationStatus Status { get; set; }

    public static DayWill From(DateTime date, Will will) 
        => new DayWill(date, will);
}