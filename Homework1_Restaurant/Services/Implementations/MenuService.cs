
using Homework1_Restaurant.Models;

namespace Homework1_Restaurant.Services.Implementations
{
    public class MenuService : IMenuService
    {
        public List<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>()
            {
                new MenuItem() { Id = 1, Name = "Irish stew", Price = 120 },
                new MenuItem() { Id = 2, Name = "Soda Bread", Price = 50 },
                new MenuItem() { Id = 2, Name = "Boxty", Price = 90 },
                new MenuItem() { Id = 2, Name = "White Pudding", Price = 75 },
                new MenuItem() { Id = 2, Name = "Ulster Fry", Price = 120 }
            };
        }
    }
}
