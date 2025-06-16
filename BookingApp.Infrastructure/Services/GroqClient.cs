using System.Text.Json;
using System.Text;
using BookingApp.Application.Interfaces;
using Microsoft.Extensions.Configuration;
namespace BookingApp.Infrastructure.Services
{
    public class GroqClient : IGroqClient
    {
        private readonly HttpClient _httpClient;
        private readonly string model = "llama-3.3-70b-versatile";
        private readonly float temperature = 0;
        private const string endpoint = "openai/v1/chat/completions";
        public GroqClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SendRequest(string instructions, string context, string input, string expectedOutput)
        {
            var body = new
            {
                model,
                temperature,
                messages = new[]
                {
                    new { role = "system", content = $"{instructions}\n\nContext: {context}\n\nExpected output examples: {expectedOutput}" },
                    new { role = "user", content = input }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);

            var parsedResponse = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            var result = parsedResponse.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
            return result;
        }
    }
}
