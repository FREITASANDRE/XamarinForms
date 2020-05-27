using Agenda.Models;
using Agenda.Services;
using Agenda.ViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarEventos : ContentPage
    {
        private readonly DbContext dbContext = new DbContext(App.DbPath);
        public ListarEventos()
        {
            InitializeComponent();
            AtualizaLista();
        }

        public void AtualizaLista()
        {
            ListaEventos.ItemsSource = dbContext.Listar();
            ListaEventos.IsRefreshing = false;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new Cadastro()), true);
        }
        public async void OnDelete(object sender, EventArgs e)
        {
            var layout = (BindableObject)sender;
            var item = (Evento)layout.BindingContext;
            bool response = await DisplayAlert("Deseja realmente deletar esse registro? ", "", "Deletar", "Cancelar");
            if (response)
            {
                dbContext.Delete(item);
                await DisplayAlert("Deletar", dbContext.StatusMessage, "OK");
                AtualizaLista();
            }
        }

        private void ListaEventos_Refreshing(object sender, EventArgs e)
        {
            AtualizaLista();
        }

        protected override void OnAppearing()
        {
            AtualizaLista();
        }
    }
}