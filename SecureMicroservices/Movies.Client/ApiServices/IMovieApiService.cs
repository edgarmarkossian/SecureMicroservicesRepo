using Movies.Client.Models;

namespace Movies.Client.ApiServices
{
    public interface IMovieApiService
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<Movie> GetMovieById(string id);
        Task<IEnumerable<Movie>> GetMoviesByName(string name);
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie);
        Task DeleteMovie(int id);
        Task<UserInfoViewModel> GetUserInfo();
    }
}
