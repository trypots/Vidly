using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class CustomerController : Controller
	{

		private readonly ApplicationDbContext _context;

		public CustomerController()
		{
			_context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		// GET: Customer

		[Route("customers/{index?}")]
		public ActionResult Index()
		{

			var customers = _context.Customers.ToList();
			return View(customers);
		}

		[Route("customers/details/{id}")]
		public ActionResult Details(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

    }
}