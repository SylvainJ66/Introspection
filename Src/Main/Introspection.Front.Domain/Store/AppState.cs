using Introspection.Front.Domain.Models;

namespace Introspection.Front.Domain.Store;

public record AppState
{
    public IEnumerable<DayWill>? DayWills { get; init; }

    public static AppState Empty
        => new AppState { DayWills = null };
}