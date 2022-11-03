using Introspection.Domain.Gateways.Repositories;
using Introspection.Domain.Models;

namespace Introspection.Back.Domain.UseCases;

public class DayWillsByDateQueryHandler
{
    private readonly IDayWillReadRepository _dayWillReadRepository;
    public DayWillsByDateQueryHandler(IDayWillReadRepository dayWillReadRepository) 
        => _dayWillReadRepository = dayWillReadRepository ?? throw new ArgumentNullException();
    public async Task<IEnumerable<DayWill>> Handle(DateTime date) 
        => await _dayWillReadRepository.ByDate(date);
}