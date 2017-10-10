using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PsMonitor.ModelView;
namespace PsMonitor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new Settatotali();
            ModelView.CreaGriglia griglia= new CreaGriglia();
            griglia.creaGriglia(gridLayout);

        }
    }
}
