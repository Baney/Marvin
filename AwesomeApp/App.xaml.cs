using AwesomeApp.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AwesomeApp
{

    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();
            
            MainPage = new MainPage();

            
        }

        protected override void OnStart()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "registrations.db");
            using (var db = new DatabaseContext(dbPath))
            {
                // Ensure database is created
                db.Database.EnsureCreated();

            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
