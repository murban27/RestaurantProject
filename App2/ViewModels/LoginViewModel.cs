using App2.Models;
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
                UserName = "Fill UserName",
                Password = "Fill Password"
            };
        }
    }
}
