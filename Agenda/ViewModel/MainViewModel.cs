using Agenda.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Plugin.Calendar.Models;

namespace Agenda.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly DbContext dbContext = new DbContext(App.DbPath);
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public EventCollection Events { get; set; }

        private CultureInfo _culture = CultureInfo.InvariantCulture;
        public CultureInfo Culture
        {
            get => _culture;
            set => SetProperty(ref _culture, value);
        }

        private void CarregarEventos()
        {
            Culture = CultureInfo.CreateSpecificCulture("pt-BR");

            var eventos = dbContext.Listar();

            var collection = new EventCollection();

            var eventoAgrupadoDia = eventos.GroupBy(u => u.Data.Day).Select(u => u.First());

            foreach (var evento in eventoAgrupadoDia)
            {
                collection.Add(evento.Data, eventos.Where(u => u.Data.Day == evento.Data.Day).ToList());
            }

            Events = collection;

        }

        public MainViewModel()
        {
            CarregarEventos();
        }
    }
}
