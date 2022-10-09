using Introspection.Adapters.Secondary.Repositories.InMemory;
using Introspection.Hexagon.Gateways.Repositories;
using Introspection.Hexagon.UseCases;

namespace Introspection.Unit.Hexagon.UseCases;

public class WillQueryHandlerShould
{
    private readonly IWillRepository _willRepository;

    public WillQueryHandlerShould()
    {
        _willRepository = new InMemoryWillRepository();
    }
    
    [Fact]
    public async Task Get_one_will()
    {
        var wills = await new WillQueryHandler(_willRepository)
            .Handle("SleepEarly", new DateTime(2022,01,01));
        
        Assert.Equal("SleepEarly", wills.First().Name);
    }
}