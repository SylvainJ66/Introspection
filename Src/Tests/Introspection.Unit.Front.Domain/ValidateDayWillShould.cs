using FluentAssertions;
using Introspection.Front.Domain.Models;
using Introspection.Front.Domain.Store.Actions;

namespace Introspection.Unit.Front.Domain;

public class ValidateDayWillShould : DomainContext
{
    public ValidateDayWillShould() => Dispatcher.Dispatch(new LoadDayWills());

    [Fact]
    public async Task Change_a_daywill_status_to_validate()
    {
        var dayWill = State.Value.DayWills!.First();
        Dispatcher.Dispatch(new ValidateDayWill(dayWill, DayValidationStatus.Validated));
        State.Value.DayWills!.First().Status.Should().Be(DayValidationStatus.Validated);
    }
    
    [Fact]
    public async Task Change_a_daywill_status_to_missed()
    {
        var dayWill = State.Value.DayWills!.First();
        Dispatcher.Dispatch(new ValidateDayWill(dayWill, DayValidationStatus.Missed));
        State.Value.DayWills!.First().Status.Should().Be(DayValidationStatus.Missed);
    }
}