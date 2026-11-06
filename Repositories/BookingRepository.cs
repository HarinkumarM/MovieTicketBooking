
using Microsoft.EntityFrameworkCore;
using MovieTicketBookingAPI.Data;
using MovieTicketBookingAPI.Entities;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(b => b.BookingSeats)
                .ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.BookingSeats)
                .ThenInclude(bs => bs.ShowSeat)
                .ThenInclude(ss => ss.Seat)
                .FirstOrDefaultAsync(b => b.BookingId == id);
        }
        public async Task<Show?> GetShowByIdAsync(int showId)
        {
            return await _context.Shows.FindAsync(showId);
        }

        public async Task<List<ShowSeat>> GetAvailableShowSeatsAsync(
            int showId, List<int> seatIds)
        {
            return await _context.ShowSeats
                .Where(ss =>
                    ss.ShowId == showId &&
                    seatIds.Contains(ss.SeatId) &&
                    ss.Status == "Available")
                .ToListAsync();
        }

        public async Task AddAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);

            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateShowSeatsAsync(List<ShowSeat> showSeats)
        {
            _context.ShowSeats.UpdateRange(showSeats);
            await _context.SaveChangesAsync();
        }
    }
}
