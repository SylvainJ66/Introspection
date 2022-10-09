using Introspection.Hexagon.Gateways.Repositories;
using Introspection.Hexagon.Models;

namespace Introspection.Hexagon.UseCases;

public class DayWillsQueryHandler
{
    private readonly IWillRepository _willRepository;
    public DayWillsQueryHandler(IWillRepository willRepository) 
        => _willRepository = willRepository ?? throw new ArgumentNullException();

    public async Task<IEnumerable<Will>> Handle(DateTime date) 
        => await _willRepository.ByDay(date);
}