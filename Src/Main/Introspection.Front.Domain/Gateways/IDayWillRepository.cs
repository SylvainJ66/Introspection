using Introspection.Front.Domain.Models;

namespace Introspection.Front.Domain.Gateways;

public interface IDayWillRepository
{
    Task<IEnumerable<DayWill>?> ByDate(DateTime date);
}