using CoreMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreMvc.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public PieController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}