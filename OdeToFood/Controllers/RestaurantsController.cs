using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
	[Authorize]
	public class RestaurantsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public RestaurantsController(ApplicationDbContext context)
		{
			_context = context;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			return View(await _context.Restaurants.ToListAsync());
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var restaurant = await _context.Restaurants
							.FirstOrDefaultAsync(m => m.Id == id);
			if (restaurant == null)
			{
				return NotFound();
			}

			return View(restaurant);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,City,Country")] Restaurant restaurant)
		{
			if (ModelState.IsValid)
			{
				_context.Add(restaurant);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(restaurant);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var restaurant = await _context.Restaurants.FindAsync(id);
			if (restaurant == null)
			{
				return NotFound();
			}
			return View(restaurant);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,City,Country")] Restaurant restaurant)
		{
			if (id != restaurant.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(restaurant);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!RestaurantExists(restaurant.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(restaurant);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var restaurant = await _context.Restaurants
							.FirstOrDefaultAsync(m => m.Id == id);
			if (restaurant == null)
			{
				return NotFound();
			}

			return View(restaurant);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var restaurant = await _context.Restaurants.FindAsync(id);
			_context.Restaurants.Remove(restaurant);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool RestaurantExists(int id)
		{
			return _context.Restaurants.Any(e => e.Id == id);
		}
	}
}