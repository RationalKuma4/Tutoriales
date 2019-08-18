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
    public class DetailModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        private readonly IRestaurantData _restaurantData;
        public Restaunrant Restaunrant { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaunrant = _restaurantData.GteById(restaurantId);
            if (Restaunrant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}