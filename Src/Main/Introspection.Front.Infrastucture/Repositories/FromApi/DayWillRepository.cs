using System.Net.Http.Json;
using Introspection.Front.Domain.Gateways;
using Introspection.Front.Domain.Models;
using Introspection.Shared;
using Introspection.Shared.Models;
using Microsoft.AspNetCore.Http.Extensions;

namespace Introspection.Front.Infrastucture.Repositories.FromApi;

/// <summary>
/// Get day wills from api
/// </summary>
public class DayWillRepository : IDayWillRepository
{
    private readonly HttpClient _client;

    public DayWillRepository(HttpClient client) 
        => _client = client;

    public async Task<IEnumerable<DayWill>?> Today()
    {
        var dateProvider = new DeterministicDateProvider();
        dateProvider.SetDateOfNow(DateTime.Now);

        return await _client.GetFromJsonAsync<IEnumerable<DayWill>>(
            new Uri($"api/DayWill/{dateProvider:o}"));
    }
}