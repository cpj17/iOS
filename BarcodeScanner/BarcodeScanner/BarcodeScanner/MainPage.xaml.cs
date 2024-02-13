using System;
using ZXing.Net.Mobile.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BarcodeScanner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string stringbarcode = "";

                var sc = new ZXingScannerPage();
                await Navigation.PushAsync(sc);
                sc.OnScanResult += (result) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PopAsync();
                        stringbarcode = result.Text;
                        
                    });

                };
            }
            catch (Exception objException)
            {
                await DisplayAlert("Exception", "btnScanner_Clicked : " + objException, "OK");
                objException = null;
            }
        }
    }
}
