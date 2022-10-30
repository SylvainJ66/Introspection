using Introspection.Domain.Gateways.Repositories;
using Introspection.Domain.Models;

namespace Introspection.Domain.UseCases;

public class DayWillsByDateQueryHandler
{
    private readonly IDayWillRepository _dayWillRepository;
    public DayWillsByDateQueryHandler(IDayWillRepository dayWillRepository) 
        => _dayWillRepository = dayWillRepository ?? throw new ArgumentNullException();

    public async Task<IEnumerable<DayWill>> Handle(DateTime date) 
        => await _dayWillRepository.ByDate(date);
}