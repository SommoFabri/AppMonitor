using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsMonitor.Model
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaManutenzione : ContentPage
    {
        public PaginaManutenzione()
        {
            InitializeComponent();
            RefreshConnection();


        }
      
        public async void RefreshConnection()
        {
            
                Device.StartTimer(TimeSpan.FromSeconds(30), () =>
                {
                    Navigation.PushModalAsync(new MainPage());
                    return false;
                });
        }
    }
}