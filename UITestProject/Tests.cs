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
        public int Cena = 999;
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
           
            var items = app.WaitForElement(x => x.Marked("SyncfusionGrid"));
            app.DoubleTap("SyncfusionGrid Row3");


        }

    
        [Test, Order(3)]
        public void AddItemToOrder()

        {
            System.Threading.Thread.Sleep(2500);
            var items = app.WaitForElement(x => x.Marked("DatagridPolozka"));
            app.Tap("DatagridPolozka R4C2");
        }
        [Test, Order(4)]
        public void CheckCenu()

        {
            Cena = int.Parse(app.WaitForElement(x => x.Marked("LabelCena")).FirstOrDefault().Text);

        }



        [Test, Order(5)]
        public void CommitOrder()

        {

        }

    }
}
