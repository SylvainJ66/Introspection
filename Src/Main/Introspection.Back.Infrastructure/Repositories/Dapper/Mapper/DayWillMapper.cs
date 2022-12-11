using Introspection.Back.Domain.Models;
using Introspection.Back.Infrastructure.Repositories.Dapper.Entities;

namespace Introspection.Back.Infrastructure.Repositories.Dapper.Mapper;

internal static class DayWillMapper
{
    internal static DayWill ToDomain(this DayWillEntity dayWillEntity)
        => DayWill.From(dayWillEntity.Date, dayWillEntity.Will.ToDomain());
    
    internal static IEnumerable<DayWill> ToDomain(this IEnumerable<DayWillEntity> dayWillEntities)
        => dayWillEntities.Select(ToDomain);
    
    internal static Will ToDomain(this WillEntity willEntity)
        => Will.From(willEntity.Name!);
}