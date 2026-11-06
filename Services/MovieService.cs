using MovieTicketBookingAPI.Entities;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _movieRepository.AddAsync(movie);
        }

        public async Task UpdateMovieAsync(int id, Movie movie)
        {
            var existingMovie = await _movieRepository.GetByIdAsync(id);

            if (existingMovie == null)
            {
                throw new Exception("Movie not found.");
            }

            existingMovie.Title = movie.Title;
            existingMovie.Description = movie.Description;
            existingMovie.DurationMinutes = movie.DurationMinutes;
            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.Language = movie.Language;
            existingMovie.Genre = movie.Genre;

            await _movieRepository.UpdateAsync(existingMovie);
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            if (movie == null)
            {
                throw new Exception("Movie not found.");
            }

            await _movieRepository.DeleteAsync(movie);
        }
    }
}