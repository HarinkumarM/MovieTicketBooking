using MovieTicketBookingAPI.Entities;

namespace MovieTicketBookingAPI.Interfaces
{
    public interface ISeatRepository
    {
        Task<List<Seat>> GetAllAsync();
        Task<Seat?> GetByIdAsync(int id);
        Task AddAsync(Seat seat);
        Task UpdateAsync(Seat seat);
        Task DeleteAsync(Seat seat);
    }
}