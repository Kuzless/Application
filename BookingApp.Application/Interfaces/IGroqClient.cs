namespace BookingApp.Application.Interfaces
{
    public interface IGroqClient
    {
        Task<string> GenerateResponseAsync(string instructions, string context, string input, string expectedOutput);
    }
}
