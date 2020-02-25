using Restaurant.Core;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Restaurant.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
       readonly List<RestaurantList> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<RestaurantList>()
                { new RestaurantList() {id=1 , Name="Atithi" , Location="Scarborough" , Cuisine= CuisineType.Indian },
            new RestaurantList() { id=2, Name="d_spot" , Location="North York" , Cuisine=CuisineType.Italian} };
            

        }

        public RestaurantList AddRestaurant(RestaurantList addRestaurant)
        {
            restaurants.Add(addRestaurant);
            var id = restaurants.Count + 1;
            addRestaurant.id = id;
            return addRestaurant;
            
        }

        public int commit()
        {
            throw new NotImplementedException();
        }

        public RestaurantList DeleteRestaurant(RestaurantList DeleteRestaurant)
        {
             restaurants.Remove(DeleteRestaurant);
            return DeleteRestaurant;
        }

        public RestaurantList GetAllById(int id)
        {
            return restaurants.SingleOrDefault(r=> r.id == id); 
        }

        public IEnumerable<RestaurantList> GetAllByNames(string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   select r;
        }

        public RestaurantList UpdateRestaurant(RestaurantList updatedRestaurant)
        {
           var restaurant = restaurants.SingleOrDefault(r=> r.id == updatedRestaurant.id );
            if (restaurants != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}
