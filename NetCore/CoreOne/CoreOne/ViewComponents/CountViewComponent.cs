using CoreOne.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoreOne.ViewComponents
{
    public class CountViewComponent : ViewComponent
    {
        private readonly IRestaurantData _restaurantData;

        public CountViewComponent(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }


        public IViewComponentResult Invoke()
        {
            var count = _restaurantData.GetCount();
            return View(count);
        }
    }
}
