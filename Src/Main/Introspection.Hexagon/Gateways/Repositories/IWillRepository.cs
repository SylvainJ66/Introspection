using Introspection.Hexagon.Models;

namespace Introspection.Hexagon.Gateways.Repositories;

public interface IWillRepository
{
    Task<IEnumerable<Will>> ByNameAndDate(string name, DateTime date);
}