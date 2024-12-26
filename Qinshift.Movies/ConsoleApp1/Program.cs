using Newtonsoft.Json;
using Qinshift.Movies.ConsoleApp.Models;
using Qinshift.Movies.DTOs;

namespace Qinshift.Movies.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/todos";
            var toDoList = GetAllToDos(url);
            PrintTodos(toDoList);
            Console.WriteLine("==================== Movies ===================");
            Console.ReadLine();
            string apiUrl = "https://localhost:7060/api/Movies";
            var movieList = GetAllMovies(apiUrl);
            PrintAll(movieList);

        }
        public static List<ToDo> GetAllToDos(string url)
        {
            using (HttpClient _client = new HttpClient())
            {
                var response = _client.GetAsync(url).Result;
                List<ToDo> todos = JsonConvert.DeserializeObject<List<ToDo>>(response.Content.ReadAsStringAsync().Result);
                return todos;
            }
        }
        public static List<MovieDto> GetAllMovies(string url)
        {
            using (HttpClient _client = new HttpClient())
            {
                var response = _client.GetAsync(url).Result;
                List<MovieDto> movies = JsonConvert.DeserializeObject<List<MovieDto>>(response.Content.ReadAsStringAsync().Result);
                return movies;
            }
        }
        public static void PrintTodos(List<ToDo> todos)
        {
            foreach (ToDo todo in todos)
            {
                Console.WriteLine($"{todo.Id}. {todo.Title} | Status {todo.Completed}");
            }
        }
        public static void PrintAll(List<MovieDto> movies)
        {
            foreach (MovieDto movie in movies)
            {
                Console.WriteLine($"TITLE:  >> {movie.Title} <<  PLOT:  {movie.Plot}     GENRE : {movie.Genre}");
            }
        }
    } 
}

