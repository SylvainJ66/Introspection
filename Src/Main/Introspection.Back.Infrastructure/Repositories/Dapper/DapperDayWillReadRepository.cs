using Dapper;
using Introspection.Back.Domain.Gateways.Repositories;
using Introspection.Back.Domain.Models;
using Introspection.Back.Infrastructure.Repositories.Dapper.Entities;

namespace Introspection.Back.Infrastructure.Repositories.Dapper;

public class DapperDayWillReadRepository : IDayWillReadRepository
{
    private readonly IntrospectionDapperDbContext _context;

    public DapperDayWillReadRepository(IntrospectionDapperDbContext context)
    {
        _context = context ?? throw new ArgumentNullException();
    }

    public async Task<IEnumerable<DayWill>> ByDate(DateTime date)
    {
        using var connection = _context.CreateConnection();
        var query = "SELECT * FROM \"DayWill\" d inner join \"Will\" w on d.\"Idwill\" = w.Id";
        return (await connection.QueryAsync<DayWillEntity>(query)).ToDomain();
    }
}

internal static class DayWillMapper
{
    internal static DayWill ToDomain(this DayWillEntity dayWillEntity)
        => new DayWill(dayWillEntity.Date, new Will("test"));
    
    internal static IEnumerable<DayWill> ToDomain(this IEnumerable<DayWillEntity> dayWillEntities)
        => dayWillEntities.Select(ToDomain);
}