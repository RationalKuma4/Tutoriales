using CoreMvcThree.Model;
using CoreMvcThree.ViewModels;
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

        public ViewResult List()
        {
            var piesViewModel = new PieListViewModel();
            piesViewModel.Pies = _pieRepository.AllPies;
            piesViewModel.CurrentCategory = "Cheese";
            return View(piesViewModel);
        }
    }
}