using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2.Services;
using App2.Views;
using App2.Models;
using System.IO;
using Syncfusion.Buttons;
namespace App2
{
    public partial class App : Application
    {
        public static RestContext RestContext;
        public static ResourceDictionary Keys;
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTQ5Mzc1QDMxMzcyZTMyMmUzMGI5V3N4NVZySk9GUGt6L0srR2ZEZURHRFdVMDhHZ3N6TmV3Y0RDdis3cms9");
            InitializeComponent();
            var a = Resources;
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<StolyDataService>();
            /*var DBPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Rest.db");
            if(!Directory.Exists(DBPath))
            {
                Directory.CreateDirectory(DBPath);
            }*/

            RestContext = new RestContext("check2.db");
            RestContext.Database.EnsureCreated();

            MainPage = new MainPage(); 
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
