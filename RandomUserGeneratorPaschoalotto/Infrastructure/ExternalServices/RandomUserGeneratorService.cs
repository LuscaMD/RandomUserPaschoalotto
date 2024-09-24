using Microsoft.EntityFrameworkCore;
using RandomUserGeneratorPaschoalotto.Application.Interfaces;
using RandomUserGeneratorPaschoalotto.Domain.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RandomUserGeneratorPaschoalotto.Infrastructure.ExternalServices
{
    public class RandomUserGeneratorService : IRandomUserGeneratorService
    {
        private readonly HttpClient _httpClient;

        public RandomUserGeneratorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetRandomUserAsync(int count)
        {
            var response = await _httpClient.GetStringAsync($"https://randomuser.me/api/?nat=br&results={count}");
            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(response);
            
            return apiResponse.Results;
        }

        private class ApiResponse
        {
            [JsonPropertyName("results")]
            public List<User> Results { get; set; }

            [JsonPropertyName("info")]
            public Info Info { get; set; }
        }
    }
}
