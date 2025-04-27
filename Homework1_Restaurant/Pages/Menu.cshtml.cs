using Homework1_Restaurant.Models;
using Homework1_Restaurant.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homework1_Restaurant.Pages
{
    public class MenuModel : PageModel
    {
        private readonly ILogger<MenuModel> _logger;
        private readonly IMenuService _menuService;

        public List<MenuItem> MenuItems { get; private set; }

        public MenuModel(ILogger<MenuModel> logger, IMenuService menuService)
        {
            _logger = logger;
            _menuService = menuService;
        }

        public void OnGet()
        {
            MenuItems = _menuService.GetMenuItems();
        }
    }
}
