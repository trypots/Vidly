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
		// GET: Customer

		[Route("customers/{index?}")]
		public ActionResult Index()
        {

			CustomerViewModel customers = new CustomerViewModel()
			{
				Customers = new List<Customer>()
					{
						new Customer {Name = "Customer1"},
						new Customer {Name = "Customer2"}

					}
			};

			return View(customers);
        }
    }
}