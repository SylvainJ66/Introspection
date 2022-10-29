using Introspection.Hexagon.Models;

namespace Introspection.Adapters.Primary.Store;

public record AppState
{
    public IEnumerable<DayWill> DayWills { get; init; }

    public static AppState Empty
        => new AppState { DayWills = null };
}