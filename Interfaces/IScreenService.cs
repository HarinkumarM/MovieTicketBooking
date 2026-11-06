using MovieTicketBookingAPI.Entities;

namespace MovieTicketBookingAPI.Interfaces
{
    public interface IScreenService
    {
        Task<List<Screen>> GetAllScreensAsync();
        Task<Screen?> GetScreenByIdAsync(int id);
        Task AddScreenAsync(Screen screen);
        Task UpdateScreenAsync(int id, Screen screen);
        Task DeleteScreenAsync(int id);
    }
}