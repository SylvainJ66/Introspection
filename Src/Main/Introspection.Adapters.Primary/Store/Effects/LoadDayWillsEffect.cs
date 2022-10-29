using Fluxor;
using Introspection.Adapters.Primary.Store.Actions;
using Introspection.Hexagon.Gateways.Repositories;
using Introspection.Hexagon.UseCases;

namespace Introspection.Adapters.Primary.Store.Effects;

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