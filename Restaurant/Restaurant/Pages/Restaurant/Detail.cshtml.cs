using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Core;
using Restaurant.Data;

namespace Restaurant.Pages.Restaurant
{
    public class DetailModel : PageModel
    {
        public RestaurantList restaurant { get; set; }
        [TempData]
        public String Message { get; set; }
        private readonly IRestaurantData RestaurantData;
        public DetailModel(IRestaurantData RestaurantData)
        {
            this.RestaurantData = RestaurantData;
        }

        public IActionResult OnGet(int restaurantid)
        {
            restaurant = RestaurantData.GetAllById(restaurantid);
            if (restaurant == null)
            {
               return RedirectToPage("/NotFound");
            }   
            return  Page();
        }
    }
}