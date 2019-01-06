using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
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

		public ActionResult Edit(int id)
		{
			return Content("id=" + id);
		}


		public ActionResult Index(int pageIndex=1, string sortBy="Name")
		{
			//if (!pageIndex.HasValue) { pageIndex = 1; }
			//if (sortBy is null) { sortBy = "Name"; }

			return Content(String.Format("pageIndex={0}, sortBy={1}", pageIndex, sortBy)); //Content($"pageIndex={pageIndex}, sortBy={sortBy}");
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