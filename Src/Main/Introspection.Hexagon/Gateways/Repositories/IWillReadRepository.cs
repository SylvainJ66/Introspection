using Introspection.Hexagon.Models;

namespace Introspection.Hexagon.Gateways.Repositories;

public interface IWillReadRepository
{
    Task<IEnumerable<Will>> ByNameAndDate(string name, DateTime date);
    Task<IEnumerable<Will>> ByDay(DateTime date);
}