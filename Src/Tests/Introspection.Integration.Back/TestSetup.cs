using Introspection.Back.Api.Controllers;
using Introspection.Back.Domain.Gateways.Repositories;
using Introspection.Back.Infrastructure.Repositories.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Introspection.Integration.Back;

public class TestSetup
{
    public TestSetup()
    {
        var serviceCollection = new ServiceCollection();
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(
                path: "appsettings.Testing.json",
                optional: false,
                reloadOnChange: true)
            .Build();
        serviceCollection.AddSingleton<IConfiguration>(configuration);
        serviceCollection.AddSingleton<IntrospectionDapperDbContext>();
        serviceCollection.AddSingleton<IDayWillReadRepository, DapperDayWillReadRepository>();
        serviceCollection.AddTransient<DayWillController, DayWillController>();

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    public ServiceProvider ServiceProvider { get; private set; }
}