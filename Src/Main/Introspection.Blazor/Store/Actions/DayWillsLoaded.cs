using Introspection.Domain.Models;

namespace Introspection.Blazor.Store.Actions;

public record DayWillsLoaded(IEnumerable<DayWill> DayWills);