using MovieTicketBookingAPI.Entities;

namespace MovieTicketBookingAPI.Interfaces
{
    public interface ITheatreService
    {
        Task<List<Theatre>> GetAllTheatresAsync();
        Task<Theatre?> GetTheatreByIdAsync(int id);
        Task AddTheatreAsync(Theatre theatre);
        Task UpdateTheatreAsync(int id, Theatre theatre);
        Task DeleteTheatreAsync(int id);
    }
}