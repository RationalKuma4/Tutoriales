using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MultiPage.Pages;
using Xamarin.Forms;

namespace MultiPage
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    /*public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BtnSunrise.Clicked += (s, e) => Navigation.PushAsync(new SunrisePage());
            BtnMoonPhase.Clicked += (s, e) => Navigation.PushAsync(new MoonPhasePage());
            BtnSpaceInfo.Clicked += (s, e) => Navigation.PushAsync(new AstronomicalBodiesPage());
            BtnAbout.Clicked += (s, e) => Navigation.PushAsync(new AboutPage());
        }
    }*/

    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            Children.Add(new SunrisePage());
            Children.Add(new MoonPhasePage());
            //Children.Add(new AstronomicalBodiesPage());
            Children.Add(new AboutPage());
        }
    }
}
