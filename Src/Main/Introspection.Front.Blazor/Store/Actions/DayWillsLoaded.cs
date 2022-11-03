using Introspection.Front.Domain;
using Introspection.Front.Domain.Models;

namespace Introspection.Front.Blazor.Store.Actions;

public record DayWillsLoaded(IEnumerable<DayWill> DayWills);