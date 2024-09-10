using Qinshift.Movies.DataAccess.Interface;
using Qinshift.Movies.DomainModels;

namespace Qinshift.Movies.DataAccess.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieAppDbContext _movieDb;

        public MovieRepository(MovieAppDbContext movieDb)
        {
            _movieDb = movieDb;
        }

        public void CreateMovie(Movie movie)
        {
            _movieDb.Movies.Add(movie);
            _movieDb.SaveChanges();
        }



        public List<Movie> GetAll()
        {
            var result = _movieDb.Movies.ToList();
            return result;
        }

        public Movie GetById(int id)
        {
            Movie result = _movieDb.Movies.SingleOrDefault(x => x.Id == id);
            return result;
        }

        public void UpdateMovie(int id, Movie movie)
        {
            var updateMovie = GetById(id);
            if (updateMovie != null)
            {
                updateMovie.Title = movie.Title;
                updateMovie.ReleaseDate = movie.ReleaseDate;
                updateMovie.Plot = movie.Plot;
                updateMovie.Genre = movie.Genre;
                _movieDb.SaveChanges();
            }
            else
            {
                throw new Exception($"No movie found with id [{movie}]");
            }

        }
        public void DeleteMovie(Movie movie)
        {
            _movieDb.Movies.Remove(movie);
            _movieDb.SaveChanges();
        }
        public void DeleteMovieById(int id)
        {
            var movieToDelete = GetById(id);
            DeleteMovie(movieToDelete);
        }
        public List<Movie> MoviesByGenre(GenreEnum genre)
        {
            var movieList = _movieDb.Movies.Where(x => x.Genre == genre).ToList();
            return movieList;
        }
        public List<Movie> MoviesByYear(int releaseYear)
        {
            var movieList = _movieDb.Movies.Where(x => x.ReleaseDate.Year == releaseYear).ToList();
            return movieList;

        }
        public List<Movie> MoviesByYearAndGenre (GenreEnum genre, int releaseYear)
        {
            var movieList = _movieDb.Movies.Where(x => x.ReleaseDate.Year == releaseYear && x.Genre == genre).ToList();
            return movieList;
        }
    }
}
