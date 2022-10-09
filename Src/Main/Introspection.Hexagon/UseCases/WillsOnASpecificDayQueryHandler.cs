using Introspection.Hexagon.Gateways.Repositories;
using Introspection.Hexagon.Models;

namespace Introspection.Hexagon.UseCases;

public class WillsOnASpecificDayQueryHandler
{
    private readonly IWillRepository _willRepository;
    public WillsOnASpecificDayQueryHandler(IWillRepository willRepository) 
        => _willRepository = willRepository ?? throw new ArgumentNullException();

    public async Task<IEnumerable<Will>> Handle(DateTime date) 
        => await _willRepository.ByDay(date);
}