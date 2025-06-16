using System.Text.Json;
using BookingApp.Application.Interfaces;
using BookingApp.Application.Interfaces.Booking;
using BookingApp.Domain.Interfaces;
using AutoMapper;
using BookingApp.Application.DTOs.Groq;
using Microsoft.Extensions.DependencyInjection;
using BookingApp.Application.DTOs;

namespace BookingApp.Infrastructure.Services
{
    public class GroqBookingService : IGroqBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroqClient _groqClient;
        private readonly IMapper _mapper;
        private readonly IResponseHandlerService _responseHandler;
        public GroqBookingService(IUnitOfWork unitOfWork, IGroqClient groqClient, IMapper mapper, [FromKeyedServices("groq")] IResponseHandlerService responseHandler)
        {
            _unitOfWork = unitOfWork;
            _groqClient = groqClient;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        public async Task<OperationResult<string>> GeneratePersonalBookingResponse(string message, string userId)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return _responseHandler.Handle<string>(200, data: "Sorry, I didn't understand that. Please try rephrasing your question");
            }
            var data = _mapper.Map<List<GroqBookingDataDTO>>(await _unitOfWork.BookingRepository.GetBookingsWithRoomDataByUserId(userId));
            var context = JsonSerializer.Serialize(data, new JsonSerializerOptions());
            var dateInfo = CalculateDate();
            var instructions =
                "You are a booking assistant. Your job is to answer questions related to user bookings such as booked rooms or desks." +
                "Make sure question is booking related and can be answered using given information. " +
                "If message isn't related to bookings and/or you can't answer it, respond with 'Sorry, I didn't understand that. Please try rephrasing your question'. " +
                "Bookings that doesn't have capacity considered booked desks instead of booked rooms. " +
                "Do not use ids or any dev-related data in responses. Use them for mapping similar records if needed. " +
                //"By default, when deciding which booking to show, show only those where endDate > stated day, unless specified otherwise (expired booking for example). " +
                "If asked a question on a specific date, look for bookings that are in range of that date. " +
                "Always show specific start and end dates/times. Never use terms like 'ongoing' e.t.c. " +
                "For multi-day bookings, show the full date range clearly. " +
                "If asked about quantity (ex. 'how many', 'count') provide quantity and each item. " +
                "Capacity: " +
                "'for [capacity] person/people' means bookings with that capacity " +
                "Type: " +
                "'show all my [type] bookings' or 'show all [type] bookings' refer to type. " +
                "Time: " +
                "'for [period]' means 'during that time period' " +
                $"{dateInfo}";
            var output = "Response format requirements: " +
                "- Keep responses short and informative, preferably in one sentence " +
                "- Do not include explanations or reasoning " +
                "- Follow the format: '📅 <strong>Date</strong> — Room type {for X people}{desk} at Location (Start Time – End Time)'. Use first option in {} if there's a capacity, second - if not. " +
                "- Use 📅 emoji for booking date/time related entities " +
                "- Time should be formatted in 'AM/PM' format" +
                "- Use html formatting " +
                "- Each new booking record should go in new line with <br> tag, without referencing previous " +
                "- Time/Date range means 'Each day in given range, from startTime to endTime' " +
                "- If date range goes outside start month/year - end date should be written in full format next to start date " +
                $"- Today's date for reference: {DateTime.Now.ToLocalTime()}. " +
                "Examples: " +
                "Q: 'Show all my bookings for 3 people?' " +
                "A: 'No bookings found for 3 people' " +
                "Q: 'How many bookings do i have?' " +
                "A: 'You have 2 bookings:<br>📅 <strong>June 15, 2025</strong> — Meeting room for 10 people at UrbanSpace Kyiv (1:00 PM – 1:30 PM)<br>" +
                "📅 <strong>June 16, 2025</strong> — Private room for 5 people at HiveHub (2:00 PM – 3:00 PM)' " +
                "Q: 'What do I have this week?' " +
                "A: '📅 <strong>June 15, 2025</strong> — Meeting room for 10 people at UrbanSpace Kyiv (1:00 PM – 1:30 PM)<br>📅 <strong>June 16, 2025</strong> — Private room for 5 people at HiveHub (2:00 PM – 3:00 PM)' " +
                "Q: 'What about next week?' " +
                "A: 'No bookings found for next week.' ";
            var response = await _groqClient.SendRequest(instructions, context, message, output);
            return _responseHandler.Handle<string>(200, data: response);
        }

        private string CalculateDate()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            int diff = (7 + ((int)today.DayOfWeek - (int)DayOfWeek.Monday)) % 7;
            var thisWeekStart = today.AddDays(-diff);

            var result =
                $"'last week' range: {thisWeekStart.AddDays(-7):yyyy-MM-dd} - {thisWeekStart.AddDays(-1):yyyy-MM-dd} " +
                $"'this week' range: {thisWeekStart:yyyy-MM-dd} - {thisWeekStart.AddDays(6):yyyy-MM-dd} " +
                $"'next week' range: {thisWeekStart.AddDays(7):yyyy-MM-dd} - {thisWeekStart.AddDays(13):yyyy-MM-dd}";
            return result;
        }

    }
}
