using Introspection.Front.Domain.Gateways;
using Introspection.Front.Domain.Models;

namespace Introspection.Front.Infrastucture.Repositories.InMemory;

public class InMemoryDayWillRepository : IDayWillRepository
{
    /// <summary>
    /// Search a will by day
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<DayWill>?> Today()
    {
        return Task.FromResult<IEnumerable<DayWill>?>(new List<DayWill>
        {
            new(Guid.Parse("1d05b510-110c-4a5c-83f8-a86bd885d9ca"), new DateTime(2022, 01, 02),new Will("SleepEarly")),
            new(Guid.Parse("fcc57acb-d599-4164-9365-6ec688e37291"),new DateTime(2022, 01, 02),new Will("Sport")),
        });
    }
}