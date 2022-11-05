using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Introspection.Front.Blazor;
using Introspection.Front.Blazor.Store;
using Introspection.Front.Domain.Gateways;
using Introspection.Front.Infrastucture.Repositories.FromApi;
using Microsoft.Extensions.Options;
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

builder.Services.Configure<ApiConfiguration>(builder.Configuration.GetSection(nameof(ApiConfiguration)));
builder.Services.AddHttpClient<IDayWillRepository, DayWillRepository>((sp, client) =>
{
    var options = sp.GetRequiredService<IOptions<ApiConfiguration>>();
    client.BaseAddress = new Uri("https://localhost:6000");
});

await builder.Build().RunAsync();