using Introspection.Hexagon.Models;

namespace Introspection.Adapters.Primary.Store.Actions;

public record DayWillsLoaded(IEnumerable<DayWill> DayWills);