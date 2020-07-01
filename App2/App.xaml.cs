using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2.Services;
using App2.Views;
using App2.Models;
using System.IO;
using Syncfusion.Buttons;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Login = App2.Views.Login;

namespace App2
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
      
        public static ResourceDictionary Keys;
        public App()
        {
        
           

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTgyMDA5QDMxMzcyZTMzMmUzMGd3ZkkwL1plNGNINHMyZGJTdTZ3eFpiUTlDZC90cEVzelZzbVZTb2h4Qmc9");
            InitializeComponent();
            if (DesignMode.IsDesignModeEnabled)
            {
             
                return;
            }
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<StolyBackupDataService>();
            /*var DBPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Rest.db");
            if(!Directory.Exists(DBPath))
            {
                Directory.CreateDirectory(DBPath);
            }*/


            MainPage = new Login();



           // MainPage = new MainPage(); 
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
