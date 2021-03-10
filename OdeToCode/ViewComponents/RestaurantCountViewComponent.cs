using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent: ViewComponent
    {
        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.RestaurantData = restaurantData;
        }

        private readonly IRestaurantData RestaurantData;

        public IViewComponentResult Invoke()
        {
            var count = this.RestaurantData.GetCountOfRestaurants();
            return View(count);
        }

        
    }
}
