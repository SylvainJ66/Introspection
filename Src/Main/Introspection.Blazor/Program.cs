using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Introspection.Blazor;
using Introspection.Blazor.Store;
using Introspection.Infrastructure.Repositories.InMemory;
using Introspection.Domain.Gateways.Repositories;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddFluxor(opt =>
{
    opt.ScanAssemblies(typeof(AppState).Assembly);
    opt.UseReduxDevTools();
});

// Repositories
builder.Services.AddSingleton<IDayWillRepository, InMemoryDayWillRepository>();

await builder.Build().RunAsync();