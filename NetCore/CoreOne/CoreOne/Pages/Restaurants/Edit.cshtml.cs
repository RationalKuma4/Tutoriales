using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreOne.Core;
using CoreOne.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreOne.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        [BindProperty(SupportsGet = true)]
        public Restaunrant Restaunrant { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaunrant = _restaurantData.GteById(restaurantId.Value);
            }
            else
            {
                Restaunrant = new Restaunrant();
            }

            if (Restaunrant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(Restaunrant restaunrant)
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (restaunrant.Id > 0)
            {
                Restaunrant = _restaurantData.Update(restaunrant);
            }
            else
            {
                Restaunrant = _restaurantData.Add(restaunrant);
            }

            _restaurantData.Commit();
            TempData["Message"] = "Restaurant saved";
            return RedirectToPage("./Detail", new { restaurantId = Restaunrant.Id });
        }
    }
}