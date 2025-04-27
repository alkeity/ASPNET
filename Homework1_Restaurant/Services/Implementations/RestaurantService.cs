using Homework1_Restaurant.Models;

namespace Homework1_Restaurant.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        public List<Restaurant> GetRestaurants()
        {
            return new List<Restaurant>()
            {
                new Restaurant { Id = 0, Name = "Restaurant0", Address = "Somewhere in the world" },
                new Restaurant { Id = 1, Name = "Restaurant1", Address = "Also somewhere in the world" }
            };
        }
    }
}
