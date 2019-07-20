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
    public partial class AstronomicalBodiesPage : ContentPage
    {
        public AstronomicalBodiesPage()
        {
            InitializeComponent();

            btnEarth.Clicked += (s, e) => Navigation.PushAsync(new AstronomicalBodyPage(SolarSystemData.Earth));
            btnMoon.Clicked += (s, e) => Navigation.PushAsync(new AstronomicalBodyPage(SolarSystemData.Moon));
            btnSun.Clicked += (s, e) => Navigation.PushAsync(new AstronomicalBodyPage(SolarSystemData.Sun));
            btnComet.Clicked += (s, e) => Navigation.PushAsync(new AstronomicalBodyPage(SolarSystemData.HalleysComet));
        }
    }
}