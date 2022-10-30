using Introspection.Domain.Models;

namespace Introspection.Blazor.Store;

public record AppState
{
    public IEnumerable<DayWill> DayWills { get; init; }

    public static AppState Empty
        => new AppState { DayWills = null };
}