
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello master!");
            Console.WriteLine("Week2");
            Console.WriteLine("Test Branch");
            Console.WriteLine();

            List<Restaurant> restaurants = new List<Restaurant>
            {
                new Restaurant(1, "Quanjude Roast Duck", "Beijing Cuisine", 4.5),
                new Restaurant(2, "Donglaishun Hot Pot", "Hot Pot", 4.6),
                new Restaurant(3, "Din Tai Fung", "Taiwanese Cuisine", 4.7),
                new Restaurant(4, "Huguosi Snacks", "Snacks", 4.2),
                new Restaurant(5, "Haidilao Hot Pot", "Hot Pot", 4.8)
            };

            Console.WriteLine("========== Add New Restaurant ==========");

            int newId = restaurants.Count + 1;

            Console.Write("Enter restaurant name: ");
            string name = Console.ReadLine();

            Console.Write("Enter restaurant type: ");
            string type = Console.ReadLine();

            double rating;

            while (true)
            {
                Console.Write("Enter restaurant rating (0-5): ");

                if (double.TryParse(Console.ReadLine(), out rating)
                    && rating >= 0 && rating <= 5)
                {
                    break;
                }

                Console.WriteLine("Invalid rating! Please enter a number between 0 and 5.");
            }

            Restaurant newRestaurant = new Restaurant(
                newId,
                name,
                type,
                rating
            );

            restaurants.Add(newRestaurant);

            Console.WriteLine();
            Console.WriteLine("Restaurant added successfully!");
            Console.WriteLine();

            Console.WriteLine("======================== Restaurant List ========================");
            Console.WriteLine(
                "{0,-5} {1,-25} {2,-22} {3,-10}",
                "ID", "Name", "Type", "Rating");

            Console.WriteLine(new string('-', 65));

            double averageRating = 0;
            int count = 0;

            foreach (Restaurant restaurant in restaurants)
            {

                Console.WriteLine(
                    "{0,-5} {1,-25} {2,-22} {3,-10:F1}",
                    restaurant.Id,
                    restaurant.Name,
                    restaurant.Type,
                    restaurant.Rating
                );

                averageRating += restaurant.Rating;

            }


            averageRating /= count;

            Console.WriteLine();
            Console.WriteLine("Average rating: " + averageRating.ToString("F1"));
            Console.WriteLine("Total restaurants: " + restaurants.Count);


            var highRatedRestaurants = restaurants
                .Where(r => r.Rating >= 4.5)
                .ToList();

            Console.WriteLine();
            Console.WriteLine("========== High Rated Restaurants (Rating >= 4.5) ==========");

            Console.WriteLine(
                "{0,-5} {1,-25} {2,-22} {3,-10}",
                "ID", "Name", "Type", "Rating");

            Console.WriteLine(new string('-', 65));

            foreach (Restaurant restaurant in highRatedRestaurants)
            {
                Console.WriteLine(
                    "{0,-5} {1,-25} {2,-22} {3,-10:F1}",
                    restaurant.Id,
                    restaurant.Name,
                    restaurant.Type,
                    restaurant.Rating
                );
            }

            Console.WriteLine();
            Console.WriteLine("Total high rated restaurants: " + highRatedRestaurants.Count);

            Console.WriteLine("Total restaurants: " + restaurants.Count);

            Console.WriteLine();
            Console.WriteLine("======================== Summary ========================");

            if (restaurants.Count > 0)
            {
                double highestRating = restaurants.Max(r => r.Rating);
                double lowestRating = restaurants.Min(r => r.Rating);

                var highestRestaurant = restaurants
                    .Where(r => r.Rating == highestRating);

                var lowestRestaurant = restaurants
                    .Where(r => r.Rating == lowestRating);

                Console.WriteLine("Highest Rating:");
                foreach (var restaurant in highestRestaurant)
                {
                    Console.WriteLine(
                        "{0,-5} {1,-25} {2,-22} {3,-10:F1}",
                        restaurant.Id,
                        restaurant.Name,
                        restaurant.Type,
                        restaurant.Rating
                    );
                }

                Console.WriteLine();

                Console.WriteLine("Lowest Rating:");
                foreach (var restaurant in lowestRestaurant)
                {
                    Console.WriteLine(
                        "{0,-5} {1,-25} {2,-22} {3,-10:F1}",
                        restaurant.Id,
                        restaurant.Name,
                        restaurant.Type,
                        restaurant.Rating
                    );
                }
            }


            Console.ReadKey();
        }
    }

    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }

        public Restaurant(int id, string name, string type, double rating)
        {
            Id = id;
            Name = name;
            Type = type;
            Rating = rating;
        }
    }
}
