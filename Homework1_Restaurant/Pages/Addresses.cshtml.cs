using Homework1_Restaurant.Models;
using Homework1_Restaurant.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homework1_Restaurant.Pages
{
    public class AddressesModel : PageModel
    {
        private readonly ILogger<AddressesModel> _logger;
        private readonly IRestaurantService _restaurantService;

        public List<Restaurant> restaurants { get; private set; }

        public AddressesModel(ILogger<AddressesModel> logger, IRestaurantService restaurantService)
        {
            _logger = logger;
            _restaurantService = restaurantService;
        }

        public void OnGet()
        {
            _logger.LogInformation("User visited Addresses page.");
            restaurants = _restaurantService.GetRestaurants();
        }
    }
}
