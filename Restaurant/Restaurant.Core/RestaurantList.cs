using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurant.Core
{
    public class RestaurantList
    {
        public int id { get; set; }
        [Required , MaxLength(80)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set;}
    }
}
