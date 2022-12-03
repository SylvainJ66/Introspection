namespace Introspection.Back.Infrastructure.Repositories.Dapper.Entities;

public class DayWillEntity
{
    public Guid Id { get; set; } 
    public DateTime Date { get; set; }
    public string? Status { get; set; }
    public Guid IdWill { get; set; }
}