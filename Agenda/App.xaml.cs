using Agenda.Views;
using Xamarin.Forms;

namespace Agenda
{
    public partial class App : Application
    {
        public static string DbName { get; set; }
        public static string DbPath { get; set; }
        public App(string dbPath, string dbName)
        {
            InitializeComponent();
            App.DbName = dbName;
            App.DbPath = dbPath;
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
