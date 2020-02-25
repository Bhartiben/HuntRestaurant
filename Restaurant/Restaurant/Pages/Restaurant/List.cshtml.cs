using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Restaurant.Core;
using Restaurant.Data;

namespace Restaurant.Pages.Restaurant
{
    public class ListModel : PageModel
    {
        public  IEnumerable<RestaurantList> restaurant { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        [TempData]
        public string Message { get; set; }
        private readonly IRestaurantData restaurantData;
        public ListModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public void OnGet(string SearchTerm)
        {
            restaurant = restaurantData.GetAllByNames(SearchTerm);
        }
        public IActionResult OnPost(RestaurantList restaurant)
        {
            restaurant = restaurantData.DeleteRestaurant(restaurant);
            return Page();
        }
    }
}