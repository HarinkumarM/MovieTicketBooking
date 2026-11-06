using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingAPI.Entities;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatresController : ControllerBase
    {
        private readonly ITheatreService _theatreService;

        public TheatresController(ITheatreService theatreService)
        {
            _theatreService = theatreService;
        }

        // GET: api/Theatres
        [HttpGet]
        public async Task<IActionResult> GetAllTheatres()
        {
            var theatres = await _theatreService.GetAllTheatresAsync();
            return Ok(theatres);
        }

        // GET: api/Theatres/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTheatreById(int id)
        {
            var theatre = await _theatreService.GetTheatreByIdAsync(id);

            if (theatre == null)
            {
                return NotFound();
            }

            return Ok(theatre);
        }

        // POST: api/Theatres
        [HttpPost]
        public async Task<IActionResult> AddTheatre(Theatre theatre)
        {
            await _theatreService.AddTheatreAsync(theatre);

            return CreatedAtAction(
                nameof(GetTheatreById),
                new { id = theatre.TheatreId },
                theatre);
        }

        // PUT: api/Theatres/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTheatre(int id, Theatre theatre)
        {
            var existingTheatre = await _theatreService.GetTheatreByIdAsync(id);

            if (existingTheatre == null)
            {
                return NotFound();
            }

            theatre.TheatreId = id;

            await _theatreService.UpdateTheatreAsync(id, theatre);

            return NoContent();
        }

        // DELETE: api/Theatres/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheatre(int id)
        {
            var theatre = await _theatreService.GetTheatreByIdAsync(id);

            if (theatre == null)
            {
                return NotFound();
            }

            await _theatreService.DeleteTheatreAsync(id);

            return NoContent();
        }
    }
}