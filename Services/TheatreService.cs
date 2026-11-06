using MovieTicketBookingAPI.Entities;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Services
{
    public class TheatreService : ITheatreService
    {
        private readonly ITheatreRepository _theatreRepository;

        public TheatreService(ITheatreRepository theatreRepository)
        {
            _theatreRepository = theatreRepository;
        }

        public async Task<List<Theatre>> GetAllTheatresAsync()
        {
            return await _theatreRepository.GetAllAsync();
        }

        public async Task<Theatre?> GetTheatreByIdAsync(int id)
        {
            return await _theatreRepository.GetByIdAsync(id);
        }

        public async Task AddTheatreAsync(Theatre theatre)
        {
            await _theatreRepository.AddAsync(theatre);
        }

        public async Task UpdateTheatreAsync(int id, Theatre theatre)
        {
            var existingTheatre = await _theatreRepository.GetByIdAsync(id);

            if (existingTheatre == null)
            {
                throw new Exception("Theatre not found.");
            }

            existingTheatre.Name = theatre.Name;
            existingTheatre.Location = theatre.Location;

            await _theatreRepository.UpdateAsync(existingTheatre);
        }

        public async Task DeleteTheatreAsync(int id)
        {
            var theatre = await _theatreRepository.GetByIdAsync(id);

            if (theatre == null)
            {
                throw new Exception("Theatre not found.");
            }

            await _theatreRepository.DeleteAsync(theatre);
        }
    }
}