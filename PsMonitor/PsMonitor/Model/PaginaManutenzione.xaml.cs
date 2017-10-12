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
        public void RefreshConnection()
        {
            Device.StartTimer(TimeSpan.FromSeconds(30), () =>
            {
                var vUpdatedPage = new PaginaManutenzione();
                Navigation.InsertPageBefore(vUpdatedPage, this);
                Navigation.PopAsync();
                return false;
            });
        }
    }
}