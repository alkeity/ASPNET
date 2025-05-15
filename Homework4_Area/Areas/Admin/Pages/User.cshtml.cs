using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homework4_Area.Areas.Admin.Pages
{
    public class UserModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Name { get; set; }

        public void OnGet()
        {
        }
    }
}
