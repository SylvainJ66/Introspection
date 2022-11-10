namespace Introspection.Front.Domain.Models;

/// <summary>
/// Will for a specific day
/// </summary>
public class DayWill
{
    public DayWill(Guid id, DateTime date, Will will)
    {
        Id = id;
        Date = date;
        Will = will;
    }
    public Guid Id { get; }
    public DateTime Date { get; }
    public Will Will { get; }
    public DayValidationStatus Status { get; set; } = DayValidationStatus.Missed;
}