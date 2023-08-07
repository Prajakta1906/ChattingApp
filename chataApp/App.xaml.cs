using System;
using System.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace chataApp
{
    public partial class App : Application
    {
        public static string LocalDatabase = string.Empty;
        public App(string database)

        {
            MainPage = new NavigationPage(new splashPage());
            InitializeComponent();
            LocalDatabase = database;
            
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
