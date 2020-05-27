using Agenda.Models;
using Agenda.Services;
using Agenda.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        private readonly DbContext dbContext = new DbContext(App.DbPath);
        private DateTime dateSelected = DateTime.Now;

        public Cadastro()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var nome = Nome.Text;
            var descricao = Descricao.Text;
            var data = dateSelected;

            Evento evento = new Evento();
            evento.Nome = nome;
            evento.Descricao = descricao;
            evento.Data = data;
            var retorno = dbContext.Save(evento);
            if (retorno)
            {
              await DisplayAlert("Sucesso", dbContext.StatusMessage, "OK");
            }
            await Navigation.PopModalAsync();
        }

        private void Data_DateSelected(object sender, DateChangedEventArgs e)
        {
            dateSelected = new DateTime(e.NewDate.Year,e.NewDate.Month, e.NewDate.Day);
        }

        private async void Cancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}