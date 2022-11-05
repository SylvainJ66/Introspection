using Fluxor;
using Introspection.Front.Blazor.Store;
using Introspection.Front.Domain.Store.Actions;

namespace Introspection.Front.Domain.Store;

public static class Reducers
{
    [ReducerMethod]
    public static AppState ReduceDayWillsLoaded(AppState state, DayWillsLoaded action)
    {
        return state with { DayWills = action.DayWills?.ToList() };
    }
}