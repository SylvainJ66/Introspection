using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Introspection.Adapters.Primary;
using Introspection.Adapters.Primary.Store;
using Introspection.Adapters.Secondary.Repositories.InMemory;
using Introspection.Hexagon.Gateways.Repositories;
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