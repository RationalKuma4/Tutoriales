using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPage.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MultiPage.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SunrisePage : ContentPage
    {
        ILatLongService LatLongService { get; set; }
        public SunrisePage()
        {
            InitializeComponent();
            LatLongService = new FakeLatLongService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await InitializeUI();
        }

        async Task InitializeUI()
        {
            var latLongData = await LatLongService.GetLatLong();
            var sunData = await new SunriseService().GetSunriseSunsetTimes(latLongData.Latitude, latLongData.Longitude);

            var riseTime = sunData.Sunrise.ToLocalTime();
            var setTime = sunData.Sunset.ToLocalTime();

            var span = setTime.TimeOfDay - riseTime.TimeOfDay;

            lblDate.Text = DateTime.Today.ToString("D");
            lblSunrise.Text = riseTime.ToString("h:mm tt");
            lblDaylight.Text = $"{span.Hours} hours, {span.Minutes} minutes";
            lblSunset.Text = setTime.ToString("h:mm tt");
        }
    }
}