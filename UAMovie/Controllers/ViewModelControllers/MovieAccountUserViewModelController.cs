using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UAMovie.Models;
using UAMovie.Models.ViewModels;

namespace UAMovie.Controllers.ViewModelControllers
{
    public class MovieAccountUserViewModelController : Controller
    {
        public ActionResult WriteReview(String username, String movieName)
        {

            MovieAccountUserViewModel movieAccountUserViewModel = new MovieAccountUserViewModel();
            movieAccountUserViewModel.user = new AccountUser();
            movieAccountUserViewModel.user.Username = username;
            movieAccountUserViewModel.movie = Movie.Get(movieName);
            movieAccountUserViewModel.newReview = new Review();
            return View("~/Views/Movie/WriteReview.cshtml", movieAccountUserViewModel);
        }

        public ActionResult GetReviews(String username, String movieName)
        {
            MovieAccountUserViewModel movieAccountUserViewModel = new MovieAccountUserViewModel();
            movieAccountUserViewModel.movies = new List<Movie>(); //Stupid manual instantiation of List

            movieAccountUserViewModel.user = new AccountUser();
            movieAccountUserViewModel.user.Username = username;

            movieAccountUserViewModel.movie = Movie.Get(movieName);
            movieAccountUserViewModel.reviews = new List<Review>();
            movieAccountUserViewModel.GetReviews();
            return View("~/Views/Movie/Reviews.cshtml", movieAccountUserViewModel);
        }

        public ActionResult GetNowPlaying(String username)
        {
            MovieAccountUserViewModel movieAccountUserViewModel = new MovieAccountUserViewModel();
            movieAccountUserViewModel.movies = new List<Movie>(); //Stupid manual instantiation of List

            movieAccountUserViewModel.user = new AccountUser();
            movieAccountUserViewModel.user.Username = username;
            movieAccountUserViewModel.GetNowPlaying();
            return View("~/Views/MyAccount/NowPlaying.cshtml", movieAccountUserViewModel);
        }
        public ActionResult GetMovie(String userName, String movieName)
        {
            MovieAccountUserViewModel movieAccountUserViewModel = new MovieAccountUserViewModel();
            movieAccountUserViewModel.user = new AccountUser(); //Stupid manual instantiation of user
            movieAccountUserViewModel.user.Username = userName;
            movieAccountUserViewModel.movie = Movie.Get(movieName);
            return View("~/Views/Movie/GetMovie.cshtml", movieAccountUserViewModel);
        }

        public ActionResult GetMovieDetails(String username, String movieName)
        {
            MovieAccountUserViewModel movieAccountUserViewModel = new MovieAccountUserViewModel();
            movieAccountUserViewModel.user = new AccountUser();
            movieAccountUserViewModel.user.Username = username;
            movieAccountUserViewModel.movie = Movie.Get(movieName);

            movieAccountUserViewModel.cast = new List<Cast>(); //Stupid manual instantiation of list
            movieAccountUserViewModel.GetCast();
            return View("~/Views/Movie/GetMovieDetails.cshtml", movieAccountUserViewModel);
        }
        // GET: MovieAccountUserViewModel
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovieAccountUserViewModel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieAccountUserViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieAccountUserViewModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieAccountUserViewModel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieAccountUserViewModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieAccountUserViewModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieAccountUserViewModel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}