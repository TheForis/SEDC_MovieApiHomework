using Qinshift.Movies.DTOs;
using Qinshift.Movies.Services.Interface;
using Qinshift.Movies.Services.Helper;
using Qinshift.Movies.DataAccess.Interface;
using Qinshift.Movies.DomainModels;

namespace Qinshift.Movies.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<MovieDto> GetAllMovies()
        {
            var movies = _movieRepository.GetAll();
            var moviesResult = movies.Select(x =>
                
            MovieMapper.MapToDto(x)).ToList();
                
            return moviesResult;
        }
        public MovieDto GetById(int id)
        {
            var movieResult = _movieRepository.GetById(id);
            if (movieResult != null)
            {
                return MovieMapper.MapToDto(movieResult);
            }
            else { return null; }
            
        }

        public List<MovieDto> GetMovieByGenre( string genre)
        {
            if (Enum.TryParse(typeof(GenreEnum), genre, out var parsedEnum) )
            {
                var moviesResult = _movieRepository.MoviesByGenre((GenreEnum)parsedEnum);
                if (moviesResult.Count > 0)
                {
                    return moviesResult.Select(x => MovieMapper.MapToDto(x)).ToList();
                }
                else { throw new Exception("There are no movies with that genre!"); }

            }
            else { throw new Exception($"The genre [{genre}] does not exist! Please try again!"); }

        }

        public List<MovieDto> GetMovieByYear(int year)
        {
            if (year < 1900 || year > DateTime.Now.Year)
            {
                throw new Exception("You must enter valid year");
            }
            var result = _movieRepository.MoviesByYear(year);
            if (result.Count > 0) { 
               return result.Select(x => MovieMapper.MapToDto(x)).ToList();
            }
            else { throw new Exception($"There are no movies released on {year}"); }
        }
        public List<MovieDto> GetMovieByYearAndGenre(int year, string genre)
        {
            if (year < 1900 || year > DateTime.Now.Year)
            {
                throw new Exception("You must enter valid year");
            }
            if (Enum.TryParse(typeof(GenreEnum), genre, out var parsedEnum))
            {
                var moviesResult = _movieRepository.MoviesByYearAndGenre((GenreEnum)parsedEnum, year);
                if (moviesResult.Count > 0)
                {
                    return moviesResult.Select(x => MovieMapper.MapToDto(x)).ToList();
                }
                else { throw new Exception("There are no movies with that genre and year!"); }
            }
            else
            {
                throw new Exception("There are no movies with that genre and year!");
            }
        }

        public void UpdateMovie(int id,CreateMovieDto movie)
        {
            var movieToEdit = _movieRepository.GetById(id);
            if (movieToEdit == null) throw new Exception("Movie not found!");

            var mappedMovie = MovieMapper.MapToMovie(movie);
            _movieRepository.UpdateMovie(id, mappedMovie);
        }
        public void CreateMovie(CreateMovieDto movie)
        {
            var mappedMovie = MovieMapper.MapToMovie(movie);
            _movieRepository.CreateMovie(mappedMovie);
        }

        public void DeleteMovie(int id)
        {
            var movieToDelete = _movieRepository.GetById(id);
            if (movieToDelete != null)
            {
                _movieRepository.DeleteMovie(movieToDelete);
            }
            else
            {
                throw new Exception($"Movie with id {id} does not exist!");
            }
        }

        
    }
}
