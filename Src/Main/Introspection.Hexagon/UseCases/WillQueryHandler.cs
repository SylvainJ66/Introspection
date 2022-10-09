using Introspection.Hexagon.Gateways.Repositories;
using Introspection.Hexagon.Models;

namespace Introspection.Hexagon.UseCases;

public class WillQueryHandler
{
    private readonly IWillReadRepository _willRepository;
    public WillQueryHandler(IWillReadRepository willRepository) 
        => _willRepository = willRepository ?? throw new ArgumentNullException();

    public async Task<IEnumerable<Will>> Handle(string name, DateTime date) 
        => await _willRepository.ByNameAndDate(name, date);
}