using Facs.ViewModels;
using System.Collections.Generic;

namespace Facs.Models
{
    public interface IQuoteLoader
    {
        IEnumerable<GreatQuoteViewModel> Load();
        void Save(IEnumerable<GreatQuoteViewModel> quotes);
    }
}
