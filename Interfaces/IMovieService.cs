using MovieTicketBookingAPI.Entities;

namespace MovieTicketBookingAPI.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMoviesAsync();

        Task<Movie?> GetMovieByIdAsync(int id);

        Task AddMovieAsync(Movie movie);

        Task UpdateMovieAsync(int id, Movie movie);

        Task DeleteMovieAsync(int id);
    }
}