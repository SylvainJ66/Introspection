using Fluxor;
using Introspection.Front.Blazor.Store;
using Introspection.Front.Domain.Models;
using Introspection.Front.Domain.Store.Actions;

namespace Introspection.Front.Domain.Store;

public static class Reducers
{
    [ReducerMethod]
    public static AppState ReduceDayWillsLoaded(AppState state, DayWillsLoaded action) 
        => state with { DayWills = action.DayWills?.ToList() };

    [ReducerMethod]
    public static AppState ReduceValidateDayWill(AppState state, ValidateDayWill action)
    {
        var dayWills = state.DayWills?.ToList();
        if (dayWills != null) 
            dayWills
                .FirstOrDefault(d => d.Id == action.DayWill.Id)!
                .Status = action.Status;

        return state with { DayWills = dayWills };
    }
}