using Question_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2.Repository
{
    public interface IMovieRepository
    {
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        Movie GetById(int id);
        IEnumerable<Movie> GetAll();
        IEnumerable<Movie> GetByYear(int year);
        IEnumerable<Movie> GetByDirector(string directorName);
    }
}
