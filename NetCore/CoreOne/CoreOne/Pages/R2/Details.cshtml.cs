using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreOne.Core;
using CoreOne.Data;

namespace CoreOne.R2
{
    public class DetailsModel : PageModel
    {
        private readonly CoreOne.Data.OdeToFoodDbContext _context;

        public DetailsModel(CoreOne.Data.OdeToFoodDbContext context)
        {
            _context = context;
        }

        public Restaunrant Restaunrant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaunrant = await _context.Restaunrants.FirstOrDefaultAsync(m => m.Id == id);

            if (Restaunrant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
