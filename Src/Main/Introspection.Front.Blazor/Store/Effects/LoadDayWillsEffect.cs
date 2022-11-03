using Fluxor;
using Introspection.Back.Domain.UseCases;
using Introspection.Front.Blazor.Store.Actions;
using Introspection.Front.Domain.Gateways;

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
            // TODO Call infra to get from api
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}