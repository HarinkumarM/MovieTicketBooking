using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingAPI.Entities;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreensController : ControllerBase
    {
        private readonly IScreenService _screenService;

        public ScreensController(IScreenService screenService)
        {
            _screenService = screenService;
        }

        // GET: api/Screens
        [HttpGet]
        public async Task<IActionResult> GetAllScreens()
        {
            var screens = await _screenService.GetAllScreensAsync();
            return Ok(screens);
        }

        // GET: api/Screens/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScreenById(int id)
        {
            var screen = await _screenService.GetScreenByIdAsync(id);

            if (screen == null)
            {
                return NotFound();
            }

            return Ok(screen);
        }

        // POST: api/Screens
        [HttpPost]
        public async Task<IActionResult> AddScreen(Screen screen)
        {
            await _screenService.AddScreenAsync(screen);

            return CreatedAtAction(
                nameof(GetScreenById),
                new { id = screen.ScreenId },
                screen);
        }

        // PUT: api/Screens/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScreen(int id, Screen screen)
        {
            var existingScreen = await _screenService.GetScreenByIdAsync(id);

            if (existingScreen == null)
            {
                return NotFound();
            }

            screen.ScreenId = id;

            await _screenService.UpdateScreenAsync(id, screen);

            return NoContent();
        }

        // DELETE: api/Screens/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreen(int id)
        {
            var screen = await _screenService.GetScreenByIdAsync(id);

            if (screen == null)
            {
                return NotFound();
            }

            await _screenService.DeleteScreenAsync(id);

            return NoContent();
        }
    }
}