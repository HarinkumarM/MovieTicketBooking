using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingAPI.Entities;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSeats()
        {
            var seats = await _seatService.GetAllSeatsAsync();
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeatById(int id)
        {
            var seat = await _seatService.GetSeatByIdAsync(id);

            if (seat == null)
                return NotFound();

            return Ok(seat);
        }

        [HttpPost]
        public async Task<IActionResult> AddSeat(Seat seat)
        {
            await _seatService.AddSeatAsync(seat);

            return CreatedAtAction(
                nameof(GetSeatById),
                new { id = seat.SeatId },
                seat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeat(int id, Seat seat)
        {
            var existingSeat = await _seatService.GetSeatByIdAsync(id);

            if (existingSeat == null)
                return NotFound();

            seat.SeatId = id;

            await _seatService.UpdateSeatAsync(id, seat);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            var seat = await _seatService.GetSeatByIdAsync(id);

            if (seat == null)
                return NotFound();

            await _seatService.DeleteSeatAsync(id);

            return NoContent();
        }
    }
}