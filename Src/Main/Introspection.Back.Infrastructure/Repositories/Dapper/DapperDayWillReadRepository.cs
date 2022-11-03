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
        var query = "SELECT * FROM DayWills";
        await connection.QueryAsync<DayWillEntity>(query);
        return Enumerable.Empty<DayWill>();
    }
}