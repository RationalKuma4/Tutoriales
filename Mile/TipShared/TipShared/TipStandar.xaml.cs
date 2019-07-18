using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipShared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipStandar : ContentPage
    {
        public TipStandar()
        {
            InitializeComponent();
            billInput.TextChanged += (s, e) => CalculateTip();
        }

        void CalculateTip()
        {
            double bill;

            if (Double.TryParse(billInput.Text, out bill) && bill > 0)
            {
                double tip = Math.Round(bill * 0.15, 2);
                double final = bill + tip;

                tipOutput.Text = tip.ToString("C");
                totalOutput.Text = final.ToString("C");
            }
        }

        void OnLight(object sender, EventArgs e)
        {
            Resources["FgColor"] = Color.FromHex("#606060");
            Resources["BgColor"] = Color.FromHex("#C0C0C0");
        }

        void OnDark(object sender, EventArgs e)
        {
            Resources["FgColor"] = Color.FromHex("#C0C0C0");
            Resources["BgColor"] = Color.FromHex("#606060");
        }

        void GotoCustom(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CustomTipPage());
        }
    }
}