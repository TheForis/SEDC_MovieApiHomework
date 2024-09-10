using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qinshift.Movies.DTOs;
using Qinshift.Movies.DTOs.Enums;
using Qinshift.Movies.Services.Interface;

namespace Qinshift.Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<List<MovieDto>> GetAll()
        {
            try
            {
                var result = _movieService.GetAllMovies();
                if (result.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("There are no movies in the library!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (ex.Message));
            }
        }
        [HttpGet("GetById/{id:int}")]
        [Authorize]
        public ActionResult<MovieDto> GetById([FromRoute] int id)
        {
            try
            {
                var result = _movieService.GetById(id);
                if (result == null)
                {
                    return NotFound($"There is no movie with id: {id}"!);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (ex.Message));
            }
        }
        [HttpGet("GetById")]
        [Authorize]
        public ActionResult<MovieDto> GetByIdQuery([FromQuery] int id)
        {
            try
            {
                var result = _movieService.GetById(id);
                if (result == null)
                {
                    return NotFound($"There is no movie with id: {id}!");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (ex.Message));
            }
        }
        [HttpPost("CreateNewMovie")]
        [Authorize]
        public IActionResult CreateNewMovie([FromBody] CreateMovieDto movie)
        {
            try
            {
                if (string.IsNullOrEmpty(movie.Title) || movie.ReleaseDate == null || movie.Genre == null)
                {
                    return BadRequest("You must provide the Title, Release date and genre for the movie!");
                }

                _movieService.CreateMovie(movie);
                return Ok("Movie Created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("EditMovieId/{id:int}")]
        [Authorize]
        public IActionResult UpdateMovie(int id, [FromBody] CreateMovieDto movie)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("The id must be a positive integer!");
                }
                if (string.IsNullOrEmpty(movie.Title) || movie.ReleaseDate == null || movie.Genre == null)
                {
                    return BadRequest("You must provide the Title, Release date and genre for the movie!");
                }
                _movieService.UpdateMovie(id, movie);
                return Ok("Movie successfully updated!");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, (ex.Message));
            }
        }

        [HttpDelete("DeleteMovieById/{id:int}")]
        [Authorize]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("The id must be a positive integer!");
                }
                _movieService.DeleteMovie(id);
                return Ok("Movie deleted!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("GetMoviesByGenreAndOrYear")]
        [Authorize]
        public ActionResult<List<MovieDto>> GetMovieByGenreAndOrYear(string? genre, int? year)
        {
            try
            {

                if (!string.IsNullOrEmpty(genre) && year != null)
                {
                    var result = _movieService.GetMovieByYearAndGenre((int)year, genre);
                    return Ok(result);
                }
                if (string.IsNullOrEmpty(genre))
                {
                    var result = _movieService.GetMovieByYear((int)year);
                    return Ok(result);
                }
                if (year == null)
                {
                    var result = _movieService.GetMovieByGenre(genre);
                    return Ok(result);
                }
                else { return BadRequest("Genre or year must be specified!"); }

            }
            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, (ex.Message)); }
        }

    }
}
