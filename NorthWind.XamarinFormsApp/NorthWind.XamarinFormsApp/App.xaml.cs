using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NorthWind.DAL.SQLite.Xamarin;
using Microsoft.EntityFrameworkCore;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NorthWind.XamarinFormsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            GetContext().Database.Migrate();
            MainPage = new MainPage();
        }

        public static NorthWindContext GetContext()
        {
            string dbPath = DependencyService.Get<IDataBaseService>().
                GetFullPath("NorthWind.db");

            return new NorthWindContext(dbPath);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
