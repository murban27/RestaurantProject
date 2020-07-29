using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITestProject
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [OneTimeSetUp]
        public void BeforeTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test,Order(1)]
        public void A_LoginPage()
        {
           var item = app.WaitForElement(c => c.Marked("UserLabel"));
          
            app.EnterText("UserLabel","cisnik");
            app.EnterText("PassLabel", "cisnik");
            app.Tap(x => x.Marked("Loginbtn"));
        }
        [Test, Order(2)]
        public void B_TablePage()
        {
            System.Threading.Thread.Sleep(2000);
            var items = app.WaitForElement(x => x.Marked("TestLayout"));


        }

    
        [Test, Order(3)]
        public void OrderDetailPage()

        {

        }



    }
}
