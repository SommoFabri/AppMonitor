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
   

        }
        public void Refresh()
        {
            Device.StartTimer(TimeSpan.FromSeconds(30), () =>
            {
                Navigation.InsertPageBefore(new MainPage(), this);
                Navigation.PopAsync();
               
                return false;
            });
        }
      
    }
}