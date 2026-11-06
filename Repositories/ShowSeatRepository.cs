using Microsoft.EntityFrameworkCore;
using MovieTicketBookingAPI.Data;
using MovieTicketBookingAPI.Entities;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Repositories
{
    public class ShowSeatRepository : IShowSeatRepository
    {
        private readonly ApplicationDbContext _context;

        public ShowSeatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ShowSeat>> GetSeatsByShowIdAsync(int showId)
        {
            return await _context.ShowSeats
                .Where(ss => ss.ShowId == showId)
                .Include(ss => ss.Seat)
                .ToListAsync();
        }
    }
}