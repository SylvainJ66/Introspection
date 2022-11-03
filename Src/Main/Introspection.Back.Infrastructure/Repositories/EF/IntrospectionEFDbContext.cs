using Microsoft.EntityFrameworkCore;

namespace Introspection.Back.Infrastructure.Repositories.EF;

public class IntrospectionEFDbContext : DbContext
{
    public IntrospectionEFDbContext(DbContextOptions<IntrospectionEFDbContext> options) 
        : base(options)
    {
        
    }
}