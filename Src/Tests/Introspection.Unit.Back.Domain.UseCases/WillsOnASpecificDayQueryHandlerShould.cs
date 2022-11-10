using Introspection.Back.Domain.Gateways.Repositories;
using Introspection.Back.Domain.UseCases;
using Introspection.Back.Infrastructure.Repositories.InMemory;

namespace Introspection.Unit.Back.Domain.UseCases;

public class WillsOnASpecificDayQueryHandlerShould
{    
    private readonly IDayWillRepository _dayWillRepository;

    public WillsOnASpecificDayQueryHandlerShould()
    {
        _dayWillRepository = new InMemoryDayWillRepository();
    }
    
    [Fact]
    public async Task Get_daywills()
    {
        var wills = (await new DayWillsByDateQueryHandler(_dayWillRepository)
            .Handle(new DateTime(2022,01,01))).ToList();
        
        Assert.Equal("SleepEarly", wills.First().Will.Name);
        Assert.Equal("Sport", wills.ElementAt(1).Will.Name);
    }
}