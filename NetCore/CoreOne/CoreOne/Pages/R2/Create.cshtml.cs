using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreOne.Core;
using CoreOne.Data;

namespace CoreOne.R2
{
    public class CreateModel : PageModel
    {
        private readonly CoreOne.Data.OdeToFoodDbContext _context;

        public CreateModel(CoreOne.Data.OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Restaunrant Restaunrant { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Restaunrants.Add(Restaunrant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}