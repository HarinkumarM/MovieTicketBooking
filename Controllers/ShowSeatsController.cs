using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowSeatsController : ControllerBase
    {
        private readonly IShowSeatService _showSeatService;

        public ShowSeatsController(IShowSeatService showSeatService)
        {
            _showSeatService = showSeatService;
        }

        [HttpGet("{showId}")]
        public async Task<IActionResult> GetSeatsByShowId(int showId)
        {
            var seats = await _showSeatService.GetSeatsByShowIdAsync(showId);

            if (seats.Count == 0)
                return NotFound("No seats found for this show.");

            return Ok(seats);
        }
    }
}