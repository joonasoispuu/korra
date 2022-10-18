using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OdeToFood.Models;

namespace OdeToFood.Data
{
	public class AppDataInit
	{
		public static void SeedRestaurant(ApplicationDbContext context)
		{
			if (!context.Restaurants.Any())
			{
				for (int i = 1; i <= 100; i++)
				{
					context.Restaurants.Add(
							new Restaurant
							{
								Name = $"Cinnamon Club {i}",
								City = "London",
								Country = "UK",
								Reviews = new List<RestaurantReview>()
								{
							new RestaurantReview()
							{
								Rating = 10,
								Body = "Suurepärane!"
							}
								}
							});
					context.Restaurants.Add(
						new Restaurant
						{
							Name = $"Mens Club {i}",
							City = "Berlin",
							Country = "Germany",
						});
					context.Restaurants.Add(
						new Restaurant
						{
							Name = $"Cool Food Place {i}",
							City = "Rome",
							Country = "Italy",
						});

					context.Restaurants.Add(
						new Restaurant
						{
							Name = $"Cooler Food Place {i}",
							City = "Naples",
							Country = "Italy",
						});
                }
				context.SaveChanges();
			}
		}

		public static void SeedIdentity(UserManager<UserProfile> userManager, RoleManager<AppRole> roleManager)
		{
			var role = new AppRole();
			role.Name = "Admin";
			if (!roleManager.RoleExistsAsync("Admin").Result)
			{
				var result = roleManager.CreateAsync(role).Result;
				if (!result.Succeeded)
				{
					foreach (var identityError in result.Errors)
					{
						Console.WriteLine($"Can not create role! Error: {identityError.Description}");
					}
				}
			}
		}
	}
}