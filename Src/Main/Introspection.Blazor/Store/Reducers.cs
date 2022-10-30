using Fluxor;
using Introspection.Blazor.Store.Actions;

namespace Introspection.Blazor.Store;

public static class Reducers
{
    [ReducerMethod]
    public static AppState ReduceDayWillsLoaded(AppState state, DayWillsLoaded action)
    {
        return state with { DayWills = action.DayWills.ToList() };
    }
}