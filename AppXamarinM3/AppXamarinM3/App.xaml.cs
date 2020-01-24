using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppXamarinM3.Views;
using AppXamarinM3.Services;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppXamarinM3
{
    public partial class App : Application
    {

        public static string DbName = "dbXamarinM3.db3";
        public static string DbPath = FileAccessHelper.GetLocalFilePath(DbName);

        public App()
        {
            InitializeComponent();
            MainPage = new Login();
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
