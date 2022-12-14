using Introspection.Back.Domain.Gateways.Repositories;
using Introspection.Back.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Introspection.Back.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayWillController : ControllerBase
    {
        private readonly IDayWillReadRepository _dayWillReadRepository;

        public DayWillController(IDayWillReadRepository dayWillReadRepository) 
            => _dayWillReadRepository = dayWillReadRepository;

        // GET: api/DayWill/2022-5-23
        [HttpGet("{date}", Name = "Get")]
        public async Task<IActionResult> Get(DateTime date) 
            => Ok(await new DayWillsByDateQueryHandler(_dayWillReadRepository).Handle(date));
    }
}
