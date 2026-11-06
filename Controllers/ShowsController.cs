using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingAPI.Entities;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowsController(IShowService showService)
        {
            _showService = showService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShows()
        {
            var shows = await _showService.GetAllShowsAsync();
            return Ok(shows);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShowById(int id)
        {
            var show = await _showService.GetShowByIdAsync(id);

            if (show == null)
                return NotFound();

            return Ok(show);
        }

        [HttpPost]
        public async Task<IActionResult> AddShow(Show show)
        {
            await _showService.AddShowAsync(show);

            return CreatedAtAction(
                nameof(GetShowById),
                new { id = show.ShowId },
                show);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShow(int id, Show show)
        {
            var existingShow = await _showService.GetShowByIdAsync(id);

            if (existingShow == null)
                return NotFound();

            show.ShowId = id;

            await _showService.UpdateShowAsync(id, show);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShow(int id)
        {
            var show = await _showService.GetShowByIdAsync(id);

            if (show == null)
                return NotFound();

            await _showService.DeleteShowAsync(id);

            return NoContent();
        }
    }
}