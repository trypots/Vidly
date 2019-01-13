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
	public class CustomersController : Controller
	{

		private readonly ApplicationDbContext _context;

		public CustomersController()
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

			var customers = _context.Customers.Include(c => c.MembershipType).ToList();

			return View(customers.ToList());

		}

		//[Route("customers/details/{id}")]
		//public ActionResult Details(int id)
		//{
		//	var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

		//	if (customer == null)
		//		return HttpNotFound();

		//	return View(customer);
		//}

		//public ActionResult New()
		//{
		//	var membershipTypes = _context.MembershipTypes.ToList();
		//	var viewModel = new CustomerFormViewModel
		//	{
		//		MembershipTypes = membershipTypes
		//	};

		//	return View("CustomerForm", viewModel);
		//}

		[HttpPost]
		public ActionResult Save(Customer customer)
		{
			if (customer.Id == 0)
			{
				_context.Customers.Add(customer);
			}
			else
			{
				var customerInDB =
						_context.Customers.SingleOrDefault(c => c.Id == customer.Id);
				customerInDB.Name = customer.Name;
				customerInDB.Birthdate = customer.Birthdate;
				customerInDB.MembershipTypeId = customer.MembershipTypeId;
				customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			}
			_context.SaveChanges();
			return RedirectToAction("Index", "Customers");
		}

		public ActionResult Edit(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

			if(customer == null)
			{
				return HttpNotFound();
			}

			var viewModel = new CustomerFormViewModel
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};

			return View("CustomerForm", viewModel);
		}

    }
}