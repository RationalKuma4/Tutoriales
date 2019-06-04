using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App4
{
    public class MainPage : ContentPage
    {
        readonly Entry _entry;
        readonly Button _callButton;
        private string _tranlatedNumber;

        public MainPage()
        {
            Padding = new Thickness(20, 20, 20, 20);
            var layout = new StackLayout
            {
                Spacing = 15
            };

            var label = new Label
            {
                Text = "Enter a phoneword"
            };

            _entry = new Entry
            {
                Text = "1-855-XAMARIN",
                Placeholder = "1-855-XAMARIN"
            };

            var button = new Button
            {
                Text = "Translate"
            };
            button.Clicked += OnTranslate;

            _callButton = new Button
            {
                Text = "Call",
                IsEnabled = false
            };
            _callButton.Clicked += OnCall;

            layout.Children.Add(label);
            layout.Children.Add(_entry);
            layout.Children.Add(button);
            layout.Children.Add(_callButton);

            Content = layout;
        }

        private async void OnCall(object sender, EventArgs e)
        {
            if (await DisplayAlert("Dial number", $"Would you like to call {_tranlatedNumber}?", "Yes", "No"))
            {
                try
                {
                    PhoneDialer.Open(_tranlatedNumber);
                }
                catch (ArgumentNullException)
                {
                    await DisplayAlert("Unable to dial", "Phone number was not valid", "Ok");
                }
                catch (FeatureNotSupportedException)
                {
                    await DisplayAlert("Unable to dial", "Phone DIALING NOT SUPPORTED", "Ok");
                }
                catch (Exception)
                {
                    await DisplayAlert("Unable to dial", "Phone DIALING failed", "Ok");
                }
            }
        }

        private void OnTranslate(object sender, EventArgs e)
        {
            var number = _entry.Text;
            _tranlatedNumber = PhonewordTranslator.ToNumber(number);

            if (!string.IsNullOrEmpty(_tranlatedNumber))
            {
                _callButton.IsEnabled = true;
                _callButton.Text = $"Call {_tranlatedNumber}";
            }
            else
            {
                _callButton.IsEnabled = false;
                _callButton.Text = "Call";
            }
        }
    }
}
