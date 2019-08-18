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
    public class DeleteModel : PageModel
    {
        private readonly CoreOne.Data.OdeToFoodDbContext _context;

        public DeleteModel(CoreOne.Data.OdeToFoodDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaunrant = await _context.Restaunrants.FindAsync(id);

            if (Restaunrant != null)
            {
                _context.Restaunrants.Remove(Restaunrant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
