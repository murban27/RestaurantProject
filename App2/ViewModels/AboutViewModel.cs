using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

          //  OpenWebCommand = new Command(() => Launcher.OpenAsync(new Uri("https://xamarin.com/platform")));

        }

        public ICommand OpenWebCommand { get; set; }

        public async Task<bool> OpenWebSite(string website)
        {
            OpenWebCommand = new Command(async () =>await Launcher.OpenAsync(new Uri(website)));
            return await Task.FromResult(true);
            


        }
    }
}