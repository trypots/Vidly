using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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

            return View(movie);
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


		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);

		}

    }
}