using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
	public class ReviewsController : Controller
	{
		public ActionResult Index()
		{
			var model = from review in _reviews
						orderby review.Country
						select review;
			return View(model);
		}

		public ActionResult Details(int id)
		{
			return View();
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Edit(int id)
		{
			var review = _reviews.Single(r => r.Id == id);
			return View(review);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(int id, IFormCollection collection)
		{
			var review = _reviews.Single(r => r.Id == id);
			if (await TryUpdateModelAsync(review))
			{
				return RedirectToAction("Index");
			}
			return View(review);
		}

		public ActionResult Delete(int id)
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		public static List<RestaurantReview> _reviews = new List<RestaurantReview>
		{
			new RestaurantReview
			{
				Id = 1,
				Name = "Cinnamon Club",
				City ="London",
				Country ="UK",
				Rating = 10
			},
			new RestaurantReview
			{
				Id = 2,
				Name = "Mens club",
				City ="Berlin",
				Country ="Germany",
				Rating = 10
			},
			new RestaurantReview
			{
				Id = 3,
				Name = "Cool Food Place",
				City ="Rome",
				Country ="Italy",
				Rating = 10
			}
		};
	}
}