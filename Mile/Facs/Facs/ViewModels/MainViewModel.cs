using System;
using System.Collections.ObjectModel;

namespace Facs.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        readonly Action saveQuotes;

        public MainViewModel(Action save)
        {
            saveQuotes = save;
        }

        public ObservableCollection<GreatQuoteViewModel> Quotes { get; set; }

        public GreatQuoteViewModel ItemSelected { get; set; }

        public void SaveQuotes()
        {
            saveQuotes?.Invoke();
        }
    }
}
