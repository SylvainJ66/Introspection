using Introspection.Hexagon.Models;

namespace Introspection.Hexagon.Gateways.Repositories;

public interface IDayWillReadRepository
{
    Task<IEnumerable<DayWill>> ByDate(DateTime date);
}