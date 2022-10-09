using Introspection.Hexagon.Gateways.Repositories;
using Introspection.Hexagon.Models;

namespace Introspection.Adapters.Secondary.Repositories.InMemory;

public class InMemoryWillRepository : IWillRepository
{
    /// <summary>
    /// Search by Name and date
    /// </summary>
    /// <param name="name"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    public Task<IEnumerable<Will>> ByNameAndDate(string name, DateTime date)
    {
        return Task.FromResult<IEnumerable<Will>>(new List<Will>
        {
            new("SleepEarly"),
        });
    }

    /// <summary>
    /// Search a will by day
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public Task<IEnumerable<Will>> ByDay(DateTime date)
    {
        return Task.FromResult<IEnumerable<Will>>(new List<Will>
        {
            new("SleepEarly"),
            new("Sport"),
        });
    }
}