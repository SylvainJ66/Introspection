using Introspection.Back.Domain.Models;

namespace Introspection.Back.Domain.Gateways.Repositories;

public interface IDayWillReadRepository
{
    Task<IEnumerable<DayWill>> ByDate(DateTime date);
}