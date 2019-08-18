using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreOne.Core;
using CoreOne.Data;

namespace CoreOne.R2
{
    public class EditModel : PageModel
    {
        private readonly CoreOne.Data.OdeToFoodDbContext _context;

        public EditModel(CoreOne.Data.OdeToFoodDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Restaunrant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaunrantExists(Restaunrant.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RestaunrantExists(int id)
        {
            return _context.Restaunrants.Any(e => e.Id == id);
        }
    }
}
