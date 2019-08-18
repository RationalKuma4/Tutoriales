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
    public class IndexModel : PageModel
    {
        private readonly CoreOne.Data.OdeToFoodDbContext _context;

        public IndexModel(CoreOne.Data.OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaunrant> Restaunrant { get;set; }

        public async Task OnGetAsync()
        {
            Restaunrant = await _context.Restaunrants.ToListAsync();
        }
    }
}
