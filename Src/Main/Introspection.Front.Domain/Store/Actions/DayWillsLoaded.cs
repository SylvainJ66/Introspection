using Introspection.Front.Domain.Models;

namespace Introspection.Front.Domain.Store.Actions;

public record DayWillsLoaded(IEnumerable<DayWill>? DayWills);