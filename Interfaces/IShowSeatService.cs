using MovieTicketBookingAPI.DTOs;

namespace MovieTicketBookingAPI.Interfaces
{
    public interface IShowSeatService
    {
        Task<List<ShowSeatResponseDto>> GetSeatsByShowIdAsync(int showId);
    }
}