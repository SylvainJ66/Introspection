using FluentAssertions;
using Introspection.Front.Domain.Store.Actions;
using Introspection.Front.Infrastucture.Repositories.InMemory;

namespace Introspection.Unit.Front.Domain;

public class LoadDayWillsShould : DomainContext
{
    private readonly InMemoryDayWillRepository _dayWillRepository = new();

    [Fact]
    public async Task Add_DayWills_to_state()
    {
        Dispatcher.Dispatch(new LoadDayWills());
        State.Value.DayWills.Should().NotBeNull();
        State.Value.DayWills.Should().BeEquivalentTo(await _dayWillRepository.Today());
    }
}