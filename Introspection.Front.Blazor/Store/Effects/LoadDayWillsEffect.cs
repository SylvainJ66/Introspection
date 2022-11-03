using Fluxor;
using Introspection.Back.Domain.UseCases;
using Introspection.Back.Hexagon.Gateways.Repositories;
using Introspection.Domain.Gateways.Repositories;
using Introspection.Domain.UseCases;
using Introspection.Front.Blazor.Store.Actions;

namespace Introspection.Front.Blazor.Store.Effects;

public class LoadDayWillsEffect : Effect<LoadDayWills>
{
    private readonly DayWillsByDateQueryHandler _useCase;
    
    public LoadDayWillsEffect(IDayWillRepository repo)
    {
        _useCase = new DayWillsByDateQueryHandler(repo);
    }

    public override async Task HandleAsync(LoadDayWills action, IDispatcher dispatcher)
    {
        try
        {
            var dayWills = await _useCase.Handle(action.Date);
            dispatcher.Dispatch(new DayWillsLoaded(dayWills));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}