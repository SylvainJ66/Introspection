namespace Introspection.Shared.Models;

public class DeterministicDateProvider : IDateProvider
{
    private DateTime _dateOfNow;

    public DateTime Now() => _dateOfNow;

    public void SetDateOfNow(DateTime dateOfNow) 
        => _dateOfNow = dateOfNow;
}