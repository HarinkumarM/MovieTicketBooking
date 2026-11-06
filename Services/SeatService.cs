using MovieTicketBookingAPI.Entities;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<List<Seat>> GetAllSeatsAsync()
        {
            return await _seatRepository.GetAllAsync();
        }

        public async Task<Seat?> GetSeatByIdAsync(int id)
        {
            return await _seatRepository.GetByIdAsync(id);
        }

        public async Task AddSeatAsync(Seat seat)
        {
            await _seatRepository.AddAsync(seat);
        }

        public async Task UpdateSeatAsync(int id, Seat seat)
        {
            var existingSeat = await _seatRepository.GetByIdAsync(id);

            if (existingSeat == null)
                throw new Exception("Seat not found.");

            existingSeat.ScreenId = seat.ScreenId;
            existingSeat.RowName = seat.RowName;
            existingSeat.SeatNumber = seat.SeatNumber;
            existingSeat.SeatType = seat.SeatType;

            await _seatRepository.UpdateAsync(existingSeat);
        }

        public async Task DeleteSeatAsync(int id)
        {
            var seat = await _seatRepository.GetByIdAsync(id);

            if (seat == null)
                throw new Exception("Seat not found.");

            await _seatRepository.DeleteAsync(seat);
        }
    }
}