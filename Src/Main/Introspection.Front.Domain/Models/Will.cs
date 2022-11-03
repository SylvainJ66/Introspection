namespace Introspection.Front.Domain.Models;

/// <summary>
/// Will
/// This a the "action" we want to do
/// </summary>
public class Will
{
    public Will(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
    public List<DayWill> DayWills { get; set; } = new();

    public DayValidationStatus DayValidation(DateTime date) 
        => DayWills.Any(d => d.Date.Date == date.Date) 
            ? DayWills.First(d => d.Date.Date == date.Date).Status 
            : DayValidationStatus.Missed;
}