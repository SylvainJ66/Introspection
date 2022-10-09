using Introspection.Adapters.Secondary.Repositories.InMemory;
using Introspection.Hexagon.Gateways.Repositories;
using Introspection.Hexagon.UseCases;

namespace Introspection.Unit.Hexagon.UseCases;

public class DayWillsQueryHandlerShould
{    
    private readonly IWillRepository _willRepository;

    public DayWillsQueryHandlerShould()
    {
        _willRepository = new InMemoryWillRepository();
    }
    [Fact]
    public async Task Get_wills()
    {
        var wills = (await new DayWillsQueryHandler(_willRepository)
            .Handle(new DateTime(2022,01,01))).ToList();
        
        Assert.Equal("SleepEarly", wills.First().Name);
        Assert.Equal("Sport", wills.ElementAt(1).Name);
    }
}