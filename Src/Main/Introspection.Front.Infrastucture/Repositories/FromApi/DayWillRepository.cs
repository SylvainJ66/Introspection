using System.Net.Http.Json;
using Introspection.Front.Domain.Gateways;
using Introspection.Front.Domain.Models;

namespace Introspection.Front.Infrastucture.Repositories.FromApi;

/// <summary>
/// Get day wills from api
/// </summary>
public class DayWillRepository : IDayWillRepository
{
    private readonly HttpClient _client;

    public DayWillRepository(HttpClient client) 
        => _client = client;

    public async Task<IEnumerable<DayWill>?> ByDate(DateTime date) 
        => await _client.GetFromJsonAsync<IEnumerable<DayWill>>($"api/DayWill/{date.ToString("d")}");
}