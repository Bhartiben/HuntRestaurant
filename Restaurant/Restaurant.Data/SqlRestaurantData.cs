using Microsoft.EntityFrameworkCore;
using Restaurant.Core;
using System.Collections.Generic;
using System.Linq;


namespace Restaurant.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantDbContext db;

        public SqlRestaurantData(RestaurantDbContext db)
        {
            this.db = db;
        }

        public int commit()
        {
         return db.SaveChanges();
        }

        RestaurantList IRestaurantData.AddRestaurant(RestaurantList addRestaurant)
        {
            db.Add(addRestaurant);
            return addRestaurant;
        }

        RestaurantList IRestaurantData.DeleteRestaurant(RestaurantList DeleteRestaurant)
        {
            db.Remove(DeleteRestaurant);
            return DeleteRestaurant;
        }

        RestaurantList IRestaurantData.GetAllById(int id)
        {
            return db.RestauranttList.Find(id);
        }

        IEnumerable<RestaurantList> IRestaurantData.GetAllByNames(string name)
        {
            var query = from r in db.RestauranttList
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        select r;
            return query;
        }

        RestaurantList IRestaurantData.UpdateRestaurant(RestaurantList updatedRestaurant)
        {
            var entity = db.RestauranttList.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }

}
