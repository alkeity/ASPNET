using Homework5_MVC.Models;
using Homework5_MVC.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Homework5_MVC.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [Route("/Reviews")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(new ReviewPage() { Reviews = _reviewService.GetLastReviews(20)});
        }

        [Route("/Reviews")]
        [ActionName("Index")]
        [HttpPost]
        public IActionResult AddReview(ReviewPage pageModel)
        {
            if (pageModel.NewReview.UserName == null || pageModel.NewReview.Rating < 1 || pageModel.NewReview.Rating > 5 || pageModel.NewReview.Text == null)
            {
                return BadRequest();
            }
            _reviewService.AddReview(pageModel.NewReview);
            return View(new ReviewPage() { Reviews = _reviewService.GetLastReviews(20) });
        }
    }
}
