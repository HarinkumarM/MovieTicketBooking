using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingAPI.Entities;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        // GET: api/Movies/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            await _movieService.AddMovieAsync(movie);

            return CreatedAtAction(
                nameof(GetMovieById),
                new { id = movie.MovieId },
                movie);
        }

        // PUT: api/Movies/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, Movie movie)
        {
            var existingMovie = await _movieService.GetMovieByIdAsync(id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            movie.MovieId = id;

            await _movieService.UpdateMovieAsync(id, movie);

            return NoContent();
        }

        // DELETE: api/Movies/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            await _movieService.DeleteMovieAsync(id);

            return NoContent();
        }
    }
}