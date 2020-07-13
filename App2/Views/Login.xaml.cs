using App2.Services;
using App2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public LoginViewModel viewModel;
        public Login()
        {
            InitializeComponent();

            BindingContext = viewModel = new LoginViewModel();



        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ValidateUser();

        }

        public async void ValidateUser()
        {
            Login login = new Login();
            login.UserName = UserName;
            login.Password = Password;
            AuthClient.Login = new Models.Login

            {
                Login1 = UserName.Text,
                Password = Password.Text
            };
            AuthClient.SetProperties();
            var s =await AuthClient.AuthorizationClient();
           if(s==true)
            {
                Application.Current.MainPage = new MainPage();

            }
            else
            {
                await DisplayAlert("Wrong password", "Incorrrect password", "cancel");

            }
        }
    }
}
