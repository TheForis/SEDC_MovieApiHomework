using Microsoft.EntityFrameworkCore;
using Qinshift.Movies.DomainModels;
using System.Security.Cryptography;
using System.Text;

namespace Qinshift.Movies.DataAccess
{
    public static class PopulateDb
    {
        public static string PasswordHash(string password)
        {
            MD5 md5CryptoService = MD5.Create();
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);

            byte[] hashBytes = md5CryptoService.ComputeHash(passwordBytes);

            string hashedPassword = Encoding.ASCII.GetString(hashBytes);
            return hashedPassword;

        }
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasData(new List<Movie>
                {
                new Movie
                {
                    Id = 1,
                Title = "Inception",
                Plot = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                ReleaseDate = new DateTime(2010, 7, 16),
                Genre = GenreEnum.ScienceFiction
            },
            new Movie
            {
                Id = 2,
                Title = "The Shawshank Redemption",
                Plot = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                ReleaseDate = new DateTime(1994, 9, 23),
                Genre = GenreEnum.Action
            },
            new Movie
            {
                Id = 3,
                Title = "The Godfather",
                Plot = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                ReleaseDate = new DateTime(1972, 3, 24),
                Genre = GenreEnum.Crime
            },
            new Movie
            {
                Id = 4,
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Plot = "In the Second Age of Middle-earth, the lords of Elves, Dwarves, and Men are given Rings of Power. Unbeknownst to them, the Dark Lord Sauron forges the One Ring in Mount Doom, instilling into it a great part of his power",
                ReleaseDate = new DateTime(2001, 12, 1),
                Genre = GenreEnum.ScienceFiction
            },
            new Movie
            {
                Id = 5,
                Title = "The Lord of the Rings: The Two Towers",
                Plot = "Awakening from a dream of Gandalf fighting the Balrog in Moria[a], Frodo Baggins finds himself, along with Samwise Gamgee, lost in the Emyn Muil near Mordor. They discover that they are being tracked by Gollum",
                ReleaseDate = new DateTime(2002, 12, 5),
                Genre = GenreEnum.Action
            },
            new Movie
            {
                Id = 6,
                Title = "Harry Potter",
                Plot = "Harry is a wizard.",
                ReleaseDate = new DateTime(2012, 6, 3),
                Genre = GenreEnum.Crime
            }

        }
                );
            modelBuilder.Entity<User>()
                .HasData(new List<User>
                {
                    new User
                    {
                        Id= 1,
                        FirstName = "Admin",
                        LastName = "Administrator",
                        UserName = "admin",
                        Password = PasswordHash("admin")
                    },
                    new User
                    {
                        Id= 2,
                        FirstName = "Boris",
                        LastName = "Krstovski",
                        UserName = "boris",
                        Password = PasswordHash("boris1234")
                    },
                    new User
                    {
                        Id= 3,
                        FirstName = "Test",
                        LastName = "Testing",
                        UserName = "test",
                        Password = PasswordHash("test123")
                    }
                });
        }
    }
}
