using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using BookingApp.Application.Interfaces;
using Microsoft.Extensions.Configuration;
namespace BookingApp.Infrastructure.Services
{
    public class GroqClient : IGroqClient
    {
        private readonly HttpClient _httpClient;
        private const string endpoint = "openai/v1/chat/completions";
        public GroqClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["Groq:BaseUrl"]);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration["Groq:Key"]);
        }

        public async Task<string> GenerateResponseAsync(string instructions, string context, string input, string expectedOutput)
        {
            var body = new
            {
                model = "llama-3.3-70b-versatile",
                messages = new[]
                {
                    new { role = "system", content = instructions },
                    new { role = "system", content = $"Context: {context}" },
                    new { role = "system", content = $"Expected output examples: {expectedOutput}" },
                    new { role = "user", content = input }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);

            var parsedResponse = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            var result = parsedResponse.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
            Console.WriteLine($"Groq response: {result}");
            return result;
        }
    }
}
