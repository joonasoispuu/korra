using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
	public class ReviewsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ReviewsController(ApplicationDbContext context)
		{
			_context = context;
		}

		public ActionResult Index([Bind(Prefix = "id")] int restaurantId)
		{
			var model = _context.Restaurants.Find(restaurantId);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}
	}
}