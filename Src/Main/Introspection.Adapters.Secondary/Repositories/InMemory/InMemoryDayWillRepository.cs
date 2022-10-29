using Introspection.Hexagon.Gateways.Repositories;
using Introspection.Hexagon.Models;

namespace Introspection.Adapters.Secondary.Repositories.InMemory;

public class InMemoryDayWillRepository : IDayWillRepository
{
    /// <summary>
    /// Search a will by day
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public Task<IEnumerable<DayWill>> ByDate(DateTime date)
    {
        return Task.FromResult<IEnumerable<DayWill>>(new List<DayWill>
        {
            new(new DateTime(2022, 01, 01),new Will("SleepEarly")),
            new(new DateTime(2022, 01, 01),new Will("Sport")),
        });
    }
}