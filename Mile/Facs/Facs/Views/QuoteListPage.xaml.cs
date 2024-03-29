﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Facs.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuoteListPage : ContentPage
    {
        public QuoteListPage()
        {
            InitializeComponent();

            BindingContext = App.GreatQuotesViewModel;
        }

        async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            await this.Navigation.PushAsync(new QuoteDetailPage());
        }
    }
}