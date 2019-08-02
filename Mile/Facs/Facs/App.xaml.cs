using Facs.ViewModels;
using Facs.Views;
using Xamarin.Forms;

namespace Facs
{
    public partial class App : Application
    {
        public static MainViewModel GreatQuotesViewModel { get; internal set; }

        public App(MainViewModel greatQuotes)
        {
            InitializeComponent();
            GreatQuotesViewModel = greatQuotes;
            MainPage = new NavigationPage(new QuoteListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            GreatQuotesViewModel.SaveQuotes();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
