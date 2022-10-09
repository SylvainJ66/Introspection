using Introspection.Adapters.Secondary.Repositories.InMemory;
using Introspection.Hexagon.Gateways.Repositories;
using Introspection.Hexagon.UseCases;

namespace Introspection.Unit.Hexagon.UseCases;

public class WillQueryHandlerShould
{
    [Fact]
    public async Task Get_one_will()
    {
        IWillRepository willRepository = new InMemoryWillRepository();
        var wills = await new WillQueryHandler(willRepository)
            .Handle("SleepEarly", new DateTime(2022,01,01));
        
        Assert.Equal("SleepEarly", wills.First().Name);
    }
}