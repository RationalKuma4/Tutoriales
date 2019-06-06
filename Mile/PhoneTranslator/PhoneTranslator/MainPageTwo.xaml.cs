using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneTranslator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageTwo : ContentPage
    {
        string translatedNumber;

        public MainPageTwo()
        {
            InitializeComponent();
        }

        void OnTranslate(object sender, EventArgs e)
        {
        }

        async void OnCall(object sender, System.EventArgs e)
        {
        }
    }
}