using Qinshift.Movies.DTOs;

namespace Qinshift.Movies.Services.Interface
{
    public interface IMovieService
    {
        List<MovieDto> GetAllMovies();
        MovieDto GetById(int id);
        List<MovieDto> GetMovieByGenre(string genre);
        List<MovieDto> GetMovieByYear(int year);
        List<MovieDto> GetMovieByYearAndGenre(int year, string genre);
        void CreateMovie(CreateMovieDto movie);
        void UpdateMovie(int id,CreateMovieDto movie);
        void DeleteMovie(int id);

    }
}
