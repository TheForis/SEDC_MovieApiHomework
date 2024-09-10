using Qinshift.Movies.DomainModels;
using Qinshift.Movies.DTOs;

namespace Qinshift.Movies.Services.Helper
{
    public static class MovieMapper
    {
        public static MovieDto MapToDto(Movie movie)
        {
            var result = new MovieDto()
            {
                Title = movie.Title,
                Plot = movie.Plot,
                ReleaseDate = movie.ReleaseDate.ToString("dd-MM-yyyy"),
                Genre = movie.Genre.ToString()

            };
            return result;
        }
        public static Movie MapToMovie(CreateMovieDto movie)
        {
            if (!Enum.TryParse(movie.Genre, out GenreEnum genreEnum)) 
            {
                throw new Exception("Please enter a valid genre. Action, Animation, Comedy, Crime, Drama, Fantasy, Historical, Romance, Horror, ScienceFiction, War");


            }
            var result = new Movie()
            {
                Title = movie.Title,
                Plot = movie.Plot,
                ReleaseDate = movie.ReleaseDate,
                Genre = genreEnum
            };
            return result;
        }
    }
}
