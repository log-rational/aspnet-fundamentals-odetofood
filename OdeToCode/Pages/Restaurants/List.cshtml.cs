using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToCode.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public ListModel(IConfiguration config, 
            IRestaurantData restaurantData, 
            ILogger<ListModel> logger)
        {
            Config = config;
            RestaurantData = restaurantData;
            Logger = logger;
        }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IConfiguration Config { get; }
        public  IRestaurantData RestaurantData { get; }
        public ILogger<ListModel> Logger { get; }

        public void OnGet()
        {
            Logger.LogError("Executing ListModel");
            if(SearchTerm != null)
            {

            Restaurants = RestaurantData.GetRestaurantsByName(SearchTerm);
            }
            else
            {
                Restaurants = RestaurantData.GetAll();
            }
            
        }
    }
}
