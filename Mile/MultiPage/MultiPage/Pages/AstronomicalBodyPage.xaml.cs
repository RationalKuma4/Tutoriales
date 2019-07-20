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
    public partial class AstronomicalBodyPage : ContentPage
    {
        public AstronomicalBodyPage(AstronomicalBody body)
        {
            InitializeComponent();

            Title = body.Name;

            lblIcon.Text = body.EmojiIcon;
            lblName.Text = body.Name;
            lblMass.Text = body.Mass;
            lblCircumference.Text = body.Circumference;
            lblAge.Text = body.Age;
        }
    }
}