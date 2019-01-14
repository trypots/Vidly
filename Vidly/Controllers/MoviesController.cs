using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

		private readonly ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ActionResult Index()
		{
			var movies = GetMovies();
			return View(movies);
		}

		private IEnumerable<Movie> GetMovies()
		{
			return _context.Movies.Include(c => c.Genre).ToList();
		}

		public ActionResult New()
		{
			var viewModel = new MovieFormViewModel()
			{
				Genres = _context.Genres.ToList()
			};
			return View("MovieForm", viewModel);
		}

		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.Include(c => c.Genre).Single(m => m.Id == id);
			if(movie == null)
			{
				return HttpNotFound();
			}
			else
			{
				return View(
						"MovieForm", 
						new MovieFormViewModel()
						{
							Movie = movie,
							Genres = _context.Genres.ToList()
						});
			}
		}


		[HttpPost]
		public ActionResult Save(Movie movie)
		{
			if(movie.Id == 0)
			{
				_context.Movies.Add(movie);
			}
			else
			{
				Movie movieInDB = _context.Movies
									.Include(c => c.Genre)
									.Single(m => m.Id == movie.Id);

				movieInDB.Name = movie.Name;
				movieInDB.GenreId = movie.GenreId;
				movieInDB.ReleaseDate = movie.ReleaseDate;
				movieInDB.NumberInStock = movie.NumberInStock;
			}
			_context.SaveChanges();

			return RedirectToAction("Index", "Movies");
		}

		[Route("movies/details/{id:int}")]
		public ActionResult Details(int id)
		{
			var movie = GetMovies().SingleOrDefault(m => m.Id == id);

			return View(movie);

		}

		public ActionResult Random()
		{
			var movie = new Movie()  // obj initialization
			{
				Name = "Shrek!"
			};
			List<Customer> customers = new List<Customer>()
			{
				new Customer { Name = "Customer1" },
				new Customer { Name = "Customer2"}
			};

			var model = new RandomMovieViewModel()
			{
				Movie = movie,
				Customers = customers
			};
			return View(model);
		}

		[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);

		}

		[Route("movies/released2/{year:int?}/{month:int?}")]
		public ActionResult ByReleaseDate2(int year = 2015, int month = 4)
		{
			return Content(year + "/" + month);

		}

	}
}