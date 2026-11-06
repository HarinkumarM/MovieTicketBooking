using MovieTicketBookingAPI.Entities;

namespace MovieTicketBookingAPI.Interfaces
{
    public interface IShowSeatRepository
    {
        Task<List<ShowSeat>> GetSeatsByShowIdAsync(int showId);
    }
}