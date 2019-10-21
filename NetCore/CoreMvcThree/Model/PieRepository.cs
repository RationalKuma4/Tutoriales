using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CoreMvcThree.Model
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _context;

        public PieRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _context.Pies
              .Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _context.Pies
                    .Include(c => c.Category)
                    .Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return _context.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
