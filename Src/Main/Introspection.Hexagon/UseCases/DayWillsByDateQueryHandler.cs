using Introspection.Hexagon.Gateways.Repositories;
using Introspection.Hexagon.Models;

namespace Introspection.Hexagon.UseCases;

public class DayWillsByDateQueryHandler
{
    private readonly IDayWillRepository _dayWillRepository;
    public DayWillsByDateQueryHandler(IDayWillRepository dayWillRepository) 
        => _dayWillRepository = dayWillRepository ?? throw new ArgumentNullException();

    public async Task<IEnumerable<DayWill>> Handle(DateTime date) 
        => await _dayWillRepository.ByDate(date);
}