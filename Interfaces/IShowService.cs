using MovieTicketBookingAPI.Entities;

namespace MovieTicketBookingAPI.Interfaces
{
    public interface IShowService
    {
        Task<List<Show>> GetAllShowsAsync();
        Task<Show?> GetShowByIdAsync(int id);
        Task AddShowAsync(Show show);
        Task UpdateShowAsync(int id, Show show);
        Task DeleteShowAsync(int id);
    }
}