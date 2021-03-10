using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        public DeleteModel(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }

        public IRestaurantData RestaurantData { get; }
        public Restaurant restaurant{ get; set; }

        public IActionResult OnGet(int restaurantId)
        {
            restaurant = RestaurantData.GetById(restaurantId);
            if(restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {

            RestaurantData.Delete(restaurantId);
            RestaurantData.Commit();

            if(restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{restaurant.Name} deleted.";
            return RedirectToPage("./List");
        }
    }
}
