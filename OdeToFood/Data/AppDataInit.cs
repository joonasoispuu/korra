using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Data
{
	public class AppDataInit
	{
		public static void SeedRestaurant(ApplicationDbContext context)
		{
			if (!context.Restaurants.Any())
			{
				for (int i = 1; i <= 1000; i++)
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
							Name = "Mens Club",
							City = "Berlin",
							Country = "Germany",
						});
					context.Restaurants.Add(
						new Restaurant
						{
							Name = "Cool Food Place",
							City = "Rome",
							Country = "Italy",
						});
				}
				context.SaveChanges();
			}
		}
	}
}