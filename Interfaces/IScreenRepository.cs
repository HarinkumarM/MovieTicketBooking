using MovieTicketBookingAPI.Entities;

namespace MovieTicketBookingAPI.Interfaces
{
    public interface IScreenRepository
    {
        Task<List<Screen>> GetAllAsync();
        Task<Screen?> GetByIdAsync(int id);
        Task AddAsync(Screen screen);
        Task UpdateAsync(Screen screen);
        Task DeleteAsync(Screen screen);
    }
}