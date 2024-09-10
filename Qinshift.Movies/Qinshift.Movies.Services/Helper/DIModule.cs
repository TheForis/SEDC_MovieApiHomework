using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Qinshift.Movies.DataAccess;
using Qinshift.Movies.DataAccess.Implementation;
using Qinshift.Movies.DataAccess.Interface;
using Qinshift.Movies.Services.Implementation;
using Qinshift.Movies.Services.Interface;

namespace Qinshift.Movies.Services.Helper
{
    public static class DIModule
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MovieAppDbContext>
                (opts => opts.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IMovieRepository), typeof(MovieRepository));
            services.AddTransient<IMovieRepository, MovieRepository>();

            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient<IUserRepository, UserRepository>();
            

            return services;
        }
    }
}
