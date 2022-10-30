using Introspection.Domain.Models;

namespace Introspection.Domain.Gateways.Repositories;

public interface IDayWillReadRepository
{
    Task<IEnumerable<DayWill>> ByDate(DateTime date);
}