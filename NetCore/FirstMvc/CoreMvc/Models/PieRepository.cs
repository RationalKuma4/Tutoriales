using System.Collections.Generic;
using System.Linq;

namespace CoreMvc.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbConetxt _appDbConetxt;

        public PieRepository(AppDbConetxt appDbConetxt)
        {
            _appDbConetxt = appDbConetxt;
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return _appDbConetxt.Pies;
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbConetxt.Pies
                .FirstOrDefault(p => p.Id == pieId);
        }
    }
}
