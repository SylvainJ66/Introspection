using Fluxor;
using Introspection.Adapters.Primary.Store.Actions;

namespace Introspection.Adapters.Primary.Store;

public static class Reducers
{
    [ReducerMethod]
    public static AppState ReduceDayWillsLoaded(AppState state, DayWillsLoaded action)
    {
        return state with { DayWills = action.DayWills.ToList() };
    }
}