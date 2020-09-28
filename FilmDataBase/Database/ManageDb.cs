using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDataBase.Database
{
    class ManageDb
    {
        static public void GetFullList()
        {
            using (var db = new MyDbContext())
            {
                var movies = db.Movies;

                foreach (var movie in movies)
                {
                    Console.WriteLine($"Title: {movie.Name} \nDirector: {movie.Director} \nYear {movie.Year}");
                    Console.WriteLine();
                }
            }
        }

        static public void AddMovie(string name, string director, int year)
        {
            using (var db = new MyDbContext())
            {
                var movie = new Movie
                {
                    Name = name,
                    Director = director,
                    Year = year
                };

                Console.WriteLine("\nMovie was added to database");
                db.Movies.Add(movie);
                db.SaveChanges();
            }
        }

        static public void SearchByYear()
        {
            using (var db = new MyDbContext())
            {
                Console.Write("Write the year: ");
                int searchYear = Convert.ToInt32(Console.ReadLine());

                var movies = db.Movies.Where(m => m.Year == searchYear).ToList();

                Console.WriteLine($"\nMovies released in {searchYear} are: \n");

                if (movies.Count > 0)
                {
                    foreach (var movie in movies)
                    {
                        Console.WriteLine($"Title: {movie.Name} \nDirector: {movie.Director}");
                    }
                }
                else
                {
                    Console.WriteLine("No movies found");
                }
            }
        }

        static public void SearchByDirector()
        {
            using (var db = new MyDbContext())
            {
                Console.Write("Write the directors last name: ");
                string searchDirector = Console.ReadLine();

                var movies = db.Movies.Where(m => m.Director ==searchDirector).ToList();

                Console.WriteLine($"\nMovies directed by {searchDirector} are: \n");

                if (movies.Count > 0)
                {
                    foreach (var movie in movies)
                    {
                        Console.WriteLine($"Title: {movie.Name} \nYear {movie.Year}");
                    }
                }
                else
                {
                    Console.WriteLine("Director not found");
                }
            }
        }

        static public void DeleteEntry()
        {
            Console.WriteLine("Select movie ID to delete title: \n");

            using (var db = new MyDbContext())
            {
                var movies = db.Movies;

                foreach (var movie in movies)
                {
                    Console.WriteLine($"{movie.MovieId}. {movie.Name}");
                }

                Console.WriteLine();
                int deletion = Convert.ToInt32(Console.ReadLine());

                var deleteTitle =
                    from item in db.Movies
                    where item.MovieId == deletion
                    select item;
                   
                foreach (var movie in deleteTitle)
                {
                    db.Movies.Remove(movie);
                    Console.WriteLine($"\n{movie.Name} deleted successfully!");
                }
                db.SaveChanges();
            }
        }
    }
}
