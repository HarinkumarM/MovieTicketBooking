
using MovieTicketBookingAPI.Entities;
using MovieTicketBookingAPI.Interfaces;
using MovieTicketBookingAPI.Exceptions;

namespace MovieTicketBookingAPI.Services
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository _showRepository;

        public ShowService(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        public async Task<List<Show>> GetAllShowsAsync()
        {
            return await _showRepository.GetAllAsync();
        }

        public async Task<Show?> GetShowByIdAsync(int id)
        {
            return await _showRepository.GetByIdAsync(id);
        }

        public async Task AddShowAsync(Show show)
        {
            // Validate show date and time
            if (show.ShowDateTime <= DateTime.Now)
                throw new BadRequestException(
                    "Show date and time must be in the future.");

            // Validate ticket price
            if (show.TicketPrice <= 0)
                throw new BadRequestException(
                    "Ticket price must be greater than zero.");

            await _showRepository.AddAsync(show);

            var seats = await _showRepository.GetSeatsByScreenIdAsync(
                show.ScreenId);

            List<ShowSeat> showSeats = new List<ShowSeat>();

            foreach (var seat in seats)
            {
                ShowSeat showSeat = new ShowSeat
                {
                    ShowId = show.ShowId,
                    SeatId = seat.SeatId,
                    Status = "Available"
                };

                showSeats.Add(showSeat);
            }

            if (showSeats.Count > 0)
            {
                await _showRepository.AddShowSeatsAsync(showSeats);
            }
        }

        public async Task UpdateShowAsync(int id, Show show)
        {
            var existingShow = await _showRepository.GetByIdAsync(id);

            if (existingShow == null)
                throw new NotFoundException("Show not found.");

            if (show.ShowDateTime <= DateTime.Now)
                throw new BadRequestException(
                    "Show date and time must be in the future.");

            if (show.TicketPrice <= 0)
                throw new BadRequestException(
                    "Ticket price must be greater than zero.");

            existingShow.MovieId = show.MovieId;
            existingShow.ScreenId = show.ScreenId;
            existingShow.ShowDateTime = show.ShowDateTime;
            existingShow.TicketPrice = show.TicketPrice;

            await _showRepository.UpdateAsync(existingShow);
        }

        public async Task DeleteShowAsync(int id)
        {
            var show = await _showRepository.GetByIdAsync(id);

            if (show == null)
                throw new NotFoundException("Show not found.");

            await _showRepository.DeleteAsync(show);
        }
    }
}
