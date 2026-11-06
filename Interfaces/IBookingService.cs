using MovieTicketBookingAPI.DTOs;
using MovieTicketBookingAPI.Entities;

namespace MovieTicketBookingAPI.Interfaces
{
    public interface IBookingService
    {
        Task<List<BookingResponseDto>> GetAllBookingsAsync();

        Task<BookingResponseDto?> GetBookingByIdAsync(int id);

        Task<BookingResponseDto> CreateBookingAsync(
            BookingRequestDto request);

        Task CancelBookingAsync(int id);
    }
}