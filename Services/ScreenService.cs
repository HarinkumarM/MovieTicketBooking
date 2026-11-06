using MovieTicketBookingAPI.Entities;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Services
{
    public class ScreenService : IScreenService
    {
        private readonly IScreenRepository _screenRepository;

        public ScreenService(IScreenRepository screenRepository)
        {
            _screenRepository = screenRepository;
        }

        public async Task<List<Screen>> GetAllScreensAsync()
        {
            return await _screenRepository.GetAllAsync();
        }

        public async Task<Screen?> GetScreenByIdAsync(int id)
        {
            return await _screenRepository.GetByIdAsync(id);
        }

        public async Task AddScreenAsync(Screen screen)
        {
            await _screenRepository.AddAsync(screen);
        }

        public async Task UpdateScreenAsync(int id, Screen screen)
        {
            var existingScreen = await _screenRepository.GetByIdAsync(id);

            if (existingScreen == null)
            {
                throw new Exception("Screen not found.");
            }

            existingScreen.TheatreId = screen.TheatreId;
            existingScreen.ScreenName = screen.ScreenName;

            await _screenRepository.UpdateAsync(existingScreen);
        }

        public async Task DeleteScreenAsync(int id)
        {
            var screen = await _screenRepository.GetByIdAsync(id);

            if (screen == null)
            {
                throw new Exception("Screen not found.");
            }

            await _screenRepository.DeleteAsync(screen);
        }
    }
}