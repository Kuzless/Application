namespace BookingApp.Application.Interfaces
{
    public interface IGroqClient
    {
        Task<string> SendRequest(string instructions, string context, string input, string expectedOutput);
    }
}
