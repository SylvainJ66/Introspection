using Dapper;
using Introspection.Back.Domain.Gateways.Repositories;
using Introspection.Back.Domain.Models;
using Introspection.Back.Infrastructure.Repositories.Dapper.Entities;
using Introspection.Back.Infrastructure.Repositories.Dapper.Mapper;

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
        string query = $"SELECT * FROM \"DayWill\" d inner join \"Will\" w on d.\"Idwill\" = w.Id where d.\"date\" = '{date}'";
        var result = await connection.QueryAsync<DayWillEntity, WillEntity, DayWillEntity>
            (query, (dayWill, will) =>
            {
                dayWill.Will = will;
                return dayWill;
            });
        return result.ToDomain();
    }
}