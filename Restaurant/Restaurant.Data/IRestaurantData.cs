using Restaurant.Core;
using System.Collections.Generic;
using System.Text;


namespace Restaurant.Data
{
    public interface IRestaurantData
    {
        IEnumerable<RestaurantList> GetAllByNames(string name);
        RestaurantList GetAllById(int id);
        RestaurantList UpdateRestaurant(RestaurantList updatedRestaurant);
        RestaurantList AddRestaurant(RestaurantList addRestaurant);
        RestaurantList DeleteRestaurant(RestaurantList DeleteRestaurant);
        int commit();
    }

}
