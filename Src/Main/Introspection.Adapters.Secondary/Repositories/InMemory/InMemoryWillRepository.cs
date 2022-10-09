using Introspection.Hexagon.Gateways.Repositories;
using Introspection.Hexagon.Models;

namespace Introspection.Adapters.Secondary.Repositories.InMemory;

public class InMemoryWillRepository : IWillRepository
{
    public Task<IEnumerable<Will>> ByNameAndDate(string name, DateTime date)
    {
        return Task.FromResult<IEnumerable<Will>>(new List<Will>
        {
            new() { Name = "SleepEarly" }
        });
    }

    public Task<IEnumerable<Will>> ByDay(DateTime date)
    {
        return Task.FromResult<IEnumerable<Will>>(new List<Will>
        {
            new() { Name = "SleepEarly" },
            new() { Name = "Sport" }
        });
    }
}