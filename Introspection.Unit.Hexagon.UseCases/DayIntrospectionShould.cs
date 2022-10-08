using Introspection.Unit.Hexagon.Models;

namespace Introspection.Unit.Hexagon.UseCases;

public class DayIntrospectionShould
{
    private DayIntrospection _dayIntrospection;

    public DayIntrospectionShould()
    {
        _dayIntrospection = new DayIntrospection(new DateTime(2022, 01, 01),"SleepEarly");
    }
    
    [Fact]
    public void Know_his_name_and_the_day()
    {
        Assert.Equal("SleepEarly", _dayIntrospection.Name);
        Assert.Equal(new DateTime(2022, 01, 01), _dayIntrospection.Day);
    }

    [Fact]
    public void Be_missed_if_no_action()
    {
        Assert.Equal(StatusDayValidation.Missed, _dayIntrospection.Status);
    }
    
    [Fact]
    public void Validate()
    {
        _dayIntrospection.Validate(StatusDayValidation.Validated);
        Assert.Equal(StatusDayValidation.Validated, _dayIntrospection.Status);
    }
}