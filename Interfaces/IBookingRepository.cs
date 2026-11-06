using MovieTicketBookingAPI.Entities;

namespace MovieTicketBookingAPI.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllAsync();

        Task<Booking?> GetByIdAsync(int id);

        Task<Show?> GetShowByIdAsync(int showId);

        Task<List<ShowSeat>> GetAvailableShowSeatsAsync(
            int showId, List<int> seatIds);

        Task AddAsync(Booking booking);

        Task UpdateAsync(Booking booking);
        Task UpdateShowSeatsAsync(List<ShowSeat> showSeats);
     
    }
}
