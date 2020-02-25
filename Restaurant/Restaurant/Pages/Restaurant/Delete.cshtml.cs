using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Data;
using Restaurant.Core;

namespace Restaurant.Pages.Restaurant
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public RestaurantList restaurants { get; set; }
        
        private readonly IRestaurantData restaurantdata;

        public DeleteModel(IRestaurantData restaurantdata)
        {   
            this.restaurantdata = restaurantdata;
        }

        public void OnGet(int restaurantid)
        {
            restaurants = restaurantdata.GetAllById(restaurantid);
        }
        public IActionResult OnPost(RestaurantList restaurants)
        {
            restaurants = restaurantdata.DeleteRestaurant(restaurants);
            restaurantdata.commit();
            TempData["Message"] = "Restaurant Deleted";
            return RedirectToPage("./List");
        }
    }
}