using MovieTicketBookingAPI.DTOs;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Services
{
    public class ShowSeatService : IShowSeatService
    {
        private readonly IShowSeatRepository _showSeatRepository;

        public ShowSeatService(IShowSeatRepository showSeatRepository)
        {
            _showSeatRepository = showSeatRepository;
        }

        public async Task<List<ShowSeatResponseDto>> GetSeatsByShowIdAsync(int showId)
        {
            var showSeats = await _showSeatRepository.GetSeatsByShowIdAsync(showId);

            return showSeats.Select(ss => new ShowSeatResponseDto
            {
                ShowSeatId = ss.ShowSeatId,
                ShowId = ss.ShowId,
                SeatId = ss.SeatId,
                RowName = ss.Seat.RowName,
                SeatNumber = ss.Seat.SeatNumber,
                SeatType = ss.Seat.SeatType,
                Status = ss.Status
            }).ToList();
        }
    }
}