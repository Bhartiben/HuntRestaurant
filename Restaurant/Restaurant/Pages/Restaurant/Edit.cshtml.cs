using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Core;
using Restaurant.Data;

namespace Restaurant.Pages.Restaurant
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public readonly IHtmlHelper htmlHelper;

       
        [BindProperty]
        public RestaurantList restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

       

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantid)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantid.HasValue)
            {
                restaurant = restaurantData.GetAllById(restaurantid.Value);

            }
            else {
                restaurant = new RestaurantList();
            }
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(RestaurantList restaurant)
        {
            if(!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();

            }


            if (restaurant.id > 0)
            {
                restaurant = restaurantData.UpdateRestaurant(restaurant);

            }
            else
            {
                restaurant = restaurantData.AddRestaurant(restaurant);
            }
            restaurantData.commit();
            TempData["Message"] = "Restaurant Saved!";
            return RedirectToPage("./Detail", new { restaurantid = restaurant.id });

        }
    }
}