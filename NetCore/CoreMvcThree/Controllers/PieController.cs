using CoreMvcThree.Model;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvcThree.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}