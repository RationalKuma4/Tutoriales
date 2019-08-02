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
    public partial class QuoteDetailPage : ContentPage
    {
        public QuoteDetailPage()
        {
            InitializeComponent();
            BindingContext = App.GreatQuotesViewModel.ItemSelected;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await this.Navigation.PopAsync();
        }

        async void Handle_ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            await this.Navigation.PushModalAsync(new NavigationPage(new EditQuotePage()));
        }
    }
}