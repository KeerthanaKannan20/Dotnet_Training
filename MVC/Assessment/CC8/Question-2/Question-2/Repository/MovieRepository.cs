using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Question_2.Models;

namespace Question_2.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private MovieDbContext db = new MovieDbContext();

        public void Add(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Update(Movie movie)
        {
            var existing = db.Movies.Find(movie.Mid);
            if (existing != null)
            {
                existing.Moviename = movie.Moviename;
                existing.DirectorName = movie.DirectorName;
                existing.DateofRelease = movie.DateofRelease;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }

        public Movie GetById(int id) => db.Movies.Find(id);

        public IEnumerable<Movie> GetAll() => db.Movies.ToList();

        public IEnumerable<Movie> GetByYear(int year) =>
            db.Movies.Where(m => m.DateofRelease.Year == year).ToList();

        public IEnumerable<Movie> GetByDirector(string directorName) =>
            db.Movies.Where(m => m.DirectorName == directorName).ToList();
    }
}
