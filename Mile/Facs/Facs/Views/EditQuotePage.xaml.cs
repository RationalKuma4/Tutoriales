using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Facs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditQuotePage : ContentPage
    {
        public EditQuotePage()
        {
            InitializeComponent();
            BindingContext = App.GreatQuotesViewModel.ItemSelected;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            App.GreatQuotesViewModel.SaveQuotes();
            await this.Navigation.PopModalAsync();
        }
    }
}