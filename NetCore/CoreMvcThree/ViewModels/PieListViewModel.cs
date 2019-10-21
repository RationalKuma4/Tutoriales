using CoreMvcThree.Model;
using System.Collections.Generic;

namespace CoreMvcThree.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }
    }
}
