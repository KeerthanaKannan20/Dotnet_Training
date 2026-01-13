using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Question_2.Models;
using Question_2.Repository;

namespace Question_2.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository repo = new MovieRepository();

        public ActionResult Index()
        {
            var movies = repo.GetAll();
            return View(movies);
        }

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int? year)
        {
            if (!year.HasValue)
            {
                ViewBag.Message = "Please enter a year to search movies.";
                return View(new List<Question_2.Models.Movie>());
            }

            ViewBag.Year = year.Value;
            var movies = repo.GetByYear(year.Value);
            return View(movies);
        }


        public ActionResult MoviesNameByDirector(string director)
        {
            if (string.IsNullOrEmpty(director))
            {
                ViewBag.Message = "Please enter a director name to search movies.";
                return View(new List<Question_2.Models.Movie>());
            }

            ViewBag.DirectorName = director;
            var movies = repo.GetByDirector(director); 
            return View(movies);
        }

    }
}

