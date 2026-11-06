using MovieTicketBookingAPI.Entities;

namespace MovieTicketBookingAPI.Interfaces
{
    public interface ISeatService
    {
        Task<List<Seat>> GetAllSeatsAsync();
        Task<Seat?> GetSeatByIdAsync(int id);
        Task AddSeatAsync(Seat seat);
        Task UpdateSeatAsync(int id, Seat seat);
        Task DeleteSeatAsync(int id);
    }
}
