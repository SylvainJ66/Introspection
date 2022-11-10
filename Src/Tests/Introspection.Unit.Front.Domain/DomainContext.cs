using Fluxor;
using Introspection.Front.Domain.Gateways;
using Introspection.Front.Domain.Store;
using Introspection.Front.Infrastucture.Repositories.InMemory;
using Introspection.Shared.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Introspection.Unit.Front.Domain;

public class DomainContext
{
    protected readonly DeterministicDateProvider DateProvider;
    protected readonly IServiceProvider ServiceProvider;
    protected readonly IStore Store;
    protected readonly IState<AppState> State;
    protected readonly IDispatcher Dispatcher;

    protected DomainContext()
    {
        DateProvider = new DeterministicDateProvider();
        DateProvider.SetDateOfNow(new DateTime(2022, 01, 02));
        
        var services = new ServiceCollection();
        services.AddSingleton<IDayWillRepository, InMemoryDayWillRepository>();
        services.AddFluxor(opt =>
        {
            opt.ScanAssemblies(typeof(AppState).Assembly);
        });
        ServiceProvider = services.BuildServiceProvider();
        Store = ServiceProvider.GetService<IStore>()!;
        State = ServiceProvider.GetService<IState<AppState>>()!;
        Store!.InitializeAsync().Wait();
        Dispatcher = ServiceProvider.GetService<IDispatcher>()!;
    }
}