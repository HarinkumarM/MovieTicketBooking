using MovieTicketBookingAPI.Entities;

namespace MovieTicketBookingAPI.Interfaces
{
    public interface IShowRepository
    {
        Task<List<Show>> GetAllAsync();
        Task<Show?> GetByIdAsync(int id);
        Task AddAsync(Show show);
        Task UpdateAsync(Show show);
        Task DeleteAsync(Show show);

        Task<List<Seat>> GetSeatsByScreenIdAsync(int screenId);
        Task AddShowSeatsAsync(List<ShowSeat> showSeats);
    }
}