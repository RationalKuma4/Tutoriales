using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreOne.Core;
using CoreOne.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreOne.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        public Restaunrant Restaunrant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaunrant = _restaurantData.GteById(restaurantId);

            if (Restaunrant == null)
            {
                return RedirectToPage("3/NotFoubd");
            }

            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var deleted = _restaurantData.Delete(restaurantId);
            _restaurantData.Commit();

            if (deleted == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"Restaurant {deleted.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}