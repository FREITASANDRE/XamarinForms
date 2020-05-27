using Agenda.ViewModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Agenda.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class EventosPage : ContentPage
    {
        public EventosPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }

        private void RefreshData()
        {
            this.BindingContext = new MainViewModel();
        }

        private void Atualizar_Clicked(object sender, System.EventArgs e)
        {
            this.RefreshData();
        }

        protected override void OnAppearing()
        {
            this.RefreshData();
        }
    }
}
