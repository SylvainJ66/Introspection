using Introspection.Hexagon.Gateways.Repositories;
using Introspection.Hexagon.Models;

namespace Introspection.Hexagon.UseCases;

public class WillQueryHandler
{
    private readonly IWillRepository _willRepository;
    
    private readonly string _name;
    private readonly DateTime _date;

    public WillQueryHandler(IWillRepository willRepository)
    {
        _willRepository = willRepository ?? throw new ArgumentNullException();
    }

    public async Task<IEnumerable<Will>> Handle(string name, DateTime date) 
        => await _willRepository.ByNameAndDate(name, date);
}