using Introspection.Back.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Introspection.Integration.Back;

public class DapperDayWillReadRepositoryShould : IClassFixture<TestSetup>
{
    private readonly DayWillController? _controller;

    public DapperDayWillReadRepositoryShould(TestSetup testSetup)
    {
        var serviceProvider = testSetup.ServiceProvider;
        _controller = serviceProvider.GetService<DayWillController>();
    }
    
    [Fact]
    public async Task Give_daywills_by_date()
    {
        var result = await _controller?.Get(new DateTime(2022, 01, 01))!;
        Assert.IsType<OkObjectResult>(result);
    }
}