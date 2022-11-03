using Introspection.Domain.Models;

namespace Introspection.Front.Blazor.Store.Actions;

public record DayWillsLoaded(IEnumerable<DayWill> DayWills);