using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(int restaurantId);
        IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm);

        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Delete(int id);
        int Commit();
        Restaurant Add(Restaurant restaurant);

        int GetCountOfRestaurants();
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            this.restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Scott's Pizza", Location="Meryland", Cuisine=CuisineType.Mexican},
                new Restaurant{ Id= 2, Name="Umesh's Pizza", Location="Wyton", Cuisine=CuisineType.Italian }, 
                new Restaurant{ Id= 3, Name="Anu's Momo", Location="Huntingdon", Cuisine=CuisineType.Indian}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return this.restaurants.OrderBy(d => d.Name);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm)
        {

            return this.restaurants.Where(d => d.Name.StartsWith(searchTerm)).OrderBy(d => d.Name);
        }

        public Restaurant GetById(int restaurantId)
        {
            Console.WriteLine(this.restaurants.Count);
            return this.restaurants.SingleOrDefault(d => d.Id == restaurantId);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = this.restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(d => d.Id) + 1;
            restaurants.Add(restaurant);
            Console.WriteLine($"Total restaurants={restaurants.Count}");
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(d => d.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
