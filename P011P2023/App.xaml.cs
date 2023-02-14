using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace P011P2023
{
    public partial class App : Application
    {

        static Controllers.DBEquipos dbequipos;

        public static Controllers.DBEquipos Dbequipos
        {
            get
            {
                if (dbequipos == null)
                {
                    var PathApp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    var DBName = Models.Configuraciones.DBname;
                    var PathFull = Path.Combine(PathApp, DBName);

                    dbequipos = new Controllers.DBEquipos(PathFull);
                }
                return dbequipos;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
