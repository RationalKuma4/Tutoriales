using CoreMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (!ModelState.IsValid) return View(feedback);

            _feedbackRepository.AddFeedback(feedback);
            return RedirectToAction("FeedbackComplete");
        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}