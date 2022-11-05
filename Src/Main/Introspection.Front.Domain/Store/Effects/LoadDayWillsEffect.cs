using Fluxor;
using Introspection.Front.Domain.Gateways;
using Introspection.Front.Domain.Store.Actions;

namespace Introspection.Front.Domain.Store.Effects;

public class LoadDayWillsEffect : Effect<LoadDayWills>
{
    private readonly IDayWillRepository _repo;

    public LoadDayWillsEffect(IDayWillRepository repo) 
        => _repo = repo;

    public override async Task HandleAsync(LoadDayWills action, IDispatcher dispatcher)
    {
        try
        {
            var dayWills = await _repo.ByDate(action.Date);
            dispatcher.Dispatch(new DayWillsLoaded(dayWills));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
            // Todo log
        }

    }
}