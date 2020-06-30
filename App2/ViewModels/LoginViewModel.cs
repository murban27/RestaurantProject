using App2.Models;
using App2.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.ViewModels
{
  public  class LoginViewModel:BaseViewModel

    {
        public Login Login { get; set; }

        public LoginViewModel()
        {
            Login login = new Login()
            {
                Login1 = "Fill UserName",
                Password = "Fill Password"
            };
   
        }
    }
}
