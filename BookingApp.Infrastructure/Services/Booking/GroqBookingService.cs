using System.Text.Json;
using BookingApp.Application.Interfaces;
using BookingApp.Application.Interfaces.Booking;
using BookingApp.Domain.Interfaces;
using AutoMapper;
using BookingApp.Application.DTOs.Groq;

namespace BookingApp.Infrastructure.Services
{
    public class GroqBookingService : IGroqBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroqClient _groqClient;
        private readonly IMapper _mapper;
        public GroqBookingService(IUnitOfWork unitOfWork, IGroqClient groqClient, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _groqClient = groqClient;
            _mapper = mapper;
        }
        public async Task<string> GeneratePersonalBookingResponse(string message, string userId)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return "Sorry, I didn't understand that. Please try rephrasing your question";
            }
            var data = _mapper.Map<List<BookingRequestGroqDTO>>(await _unitOfWork.BookingRepository.GetBookingsWithRoomDataByUserId(userId));
            var context = JsonSerializer.Serialize(data, new JsonSerializerOptions());
            var instructions = 
                "You are a booking assistant. Your job is to answer questions related to user bookings such as booked rooms or desks." +
                "Make sure question is booking related and can be answered using given information. " +
                "If message isn't related to bookings and/or you can't answer it, respond with 'Sorry, I didn't understand that. Please try rephrasing your question'. " +
                "Bookings that doesn't have capacity considered booked desks instead of booked rooms. " +
                "Do not use ids or any dev-related data in responses. Use them for mapping similar records if needed. " +
                "Each booking that you show must by default be active (must be within given day and before or during range of given time) unless specified otherwise. " +
                "If asked a question on a specific date, look for bookings that are in range of that date. " +
                "Booking considered 'active' if: 1. If pivot date is before booking enddate. 2. If pivot date is today and today's time is before booking enddate time. Otherwise it's 'inactive. " +
                "Always show specific start and end dates/times. Never use terms like 'ongoing' e.t.c. " +
                "For multi-day bookings, show the full date range clearly. " +
                "If asked about quantity (ex. 'how many', 'count') provide quantity and each item. " +
                "Capacity: " +
                "'for [capacity] person/people' means bookings with that capacity " +
                "Type: " +
                "'show all my [type] bookings' or 'show all [type] bookings' refer to type" +
                "Time: " +
                "'for [period]' means 'during that time period' " +
                "'next week' means the week starting from the next Monday " +
                "'this week' means the current week " +
                "'last week' means the week starting from the previous Monday";
            var output = "Response format requirements: " +
                "- Keep responses short and informative, preferably in one sentence " +
                "- Do not include explanations or reasoning " +
                "- Use 📅 emoji for booking date/time related entities " +
                "- Each new booking record should go in new line, without referencing previous." +
                "- Time/Date range means 'Each day in given range, from startTime to endTime' " +
                "- If date range goes outside start month/year - end date should be written in full format next to start date" +
                $"- Today's date for reference: {DateTime.Now.ToLocalTime()} " +
                "Examples: " +
                "Q: 'Show all my bookings for 3 people?' " +
                "A: 'No bookings found for 3 people'" +
                "Q: 'Show all my meeting room bookings' " +
                "A: '📅 **June 15, 2025** — Meeting room for 10 people at UrbanSpace Kyiv (13:00 – 13:30)'" +
                "Q: 'What do I have booked for next week?' " +
                "A: '📅 **June 23-27, 2025** — Private room for 5 people at HiveHub (13:00 – 13:30 daily)' " +
                "Q: 'What do I have today?' " +
                "A: '📅 **June 15, 2025** — Private room for 5 people at HiveHub (13:00 – 13:30 daily until June 27)' " +
                "Q: 'Any meetings?' " +
                "A: '📅 **June 15, 2025** — Meeting room for 10 people at UrbanSpace Kyiv (13:00 – 13:30)'" +
                "Q: 'List all my private room bookings'" +
                "A: '📅 **May 18, 2025** — Private room for 2 people at WorkClub Pechersk (10:00 – 12:00)\n" +
                "📅 **May 10, 2025 - June 25, 2026** — Private room for 2 people at UrbanSpace Podil (04:00 – 12:00)'\n" +
                "📅 **May 20, 2025** — Private room for 2 people at UrbanSpace Podil (09:00 – 17:00)'" +
                "Q: 'Do I have anything on May 12?' " +
                "A: '📅 No bookings found for May 12th.' " +
                "Q: 'What about next week?' " +
                "A: '📅 No bookings found for next week.'";
            var response = await _groqClient.GenerateResponseAsync(instructions, context, message, output);
            return response;
        }
    }
}
