using CoreOne.Core;
using CoreOne.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace CoreOne.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public IEnumerable<Restaunrant> Restaurantses;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        private readonly IConfiguration config;
        private readonly IRestaurantData _restaurantData;
        private readonly ILogger<ListModel> _logger;

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData,
            ILogger<ListModel> logger)
        {
            config = configuration;
            _restaurantData = restaurantData;
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogError("List model");
            Message = config["Message"];
            Restaurantses = _restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}