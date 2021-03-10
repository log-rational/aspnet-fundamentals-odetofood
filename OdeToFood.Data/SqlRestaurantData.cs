using System;
using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        public OdeToFoodDbContext Db { get; }
        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            Db = db;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            Db.Add(restaurant);
            return restaurant;
        }

        public int Commit()
        {
            return Db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if(restaurant != null)
            {
                Db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return Db.Restaurants.OrderBy(d => d.Name);
        }

        public Restaurant GetById(int restaurantId)
        {
            return Db.Restaurants.Find(restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm)
        {
            return Db.Restaurants
                .Where(d => d.Name.StartsWith(searchTerm) || string.IsNullOrEmpty(searchTerm))
                .OrderBy(d=>d.Name);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = Db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public int GetCountOfRestaurants()
        {
            return Db.Restaurants.Count();
        }
    }
}
