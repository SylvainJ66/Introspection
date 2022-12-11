using Introspection.Back.Domain.Models;

namespace Introspection.Common.Back;

public class DayWillTestBuilder
{
    public Guid _id = Guid.Parse("16b12459-6583-49f5-b362-d65ae9355990");
    public DateTime _date = new DateTime(2022, 01, 01);
    public static Will _will = Will.From("Sport");
    public DayValidationStatus _status = DayValidationStatus.Missed;

    public DayWillTestBuilder WithId(Guid id)
    {
        _id = id;
        return this;
    }
    
    public DayWillTestBuilder WithDate(DateTime date)
    {
        _date = date;
        return this;
    }
    
    public DayWillTestBuilder WithWill(string willName)
    {
        _will = Will.From(willName);
        return this;
    }
    
    public DayWillTestBuilder WithDayValidationStatus(DayValidationStatus status)
    {
        _status = status;
        return this;
    }

    public DayWill Build() 
        => DayWill.From(_date, _will);
}