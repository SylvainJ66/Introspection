using Introspection.Back.Domain.Gateways.Repositories;
using Introspection.Back.Domain.Models;
using Introspection.Common.Back;

namespace Introspection.Back.Infrastructure.Repositories.InMemory;

public class InMemoryDayWillRepository : IDayWillRepository
{
    /// <summary>
    /// Search a will by day
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public Task<IEnumerable<DayWill>> ByDate(DateTime date)
    {
        var dayWillBuilder = new DayWillTestBuilder();
        
        return Task.FromResult<IEnumerable<DayWill>>(new List<DayWill>
        {
            dayWillBuilder.WithWill("SleepEarly").Build(),
            dayWillBuilder.WithWill("Sport").Build(),
        });
    }
}