using System.Linq;
using CoreMvc.Models;
using CoreMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }


        public IActionResult Index()
        {
            var pies = _pieRepository.GetAllPies()
                .OrderBy(p => p.Name);
            var homeViewModel = new HomeViewModel
            {
                Title = "Welcome",
                Pies = pies.ToList()
            };
            return View(homeViewModel);
        }
    }
}