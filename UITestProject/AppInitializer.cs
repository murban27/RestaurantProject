using System;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.Queries;

namespace UITestProject
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {



                return ConfigureApp.Android.InstalledApp("com.companyname.app2").StartApp(AppDataMode.Clear);
            }
            else
            {
                return null;
            }

        
        }
    }
}