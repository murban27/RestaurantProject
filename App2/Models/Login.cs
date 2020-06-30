using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    [Serializable]
    public class Login
    {

            public int id { get; set; }
            public string Login1 { get; set; }
            public object Password { get; set; }
            public int idPozice { get; set; }
            public object idPoziceNavigation { get; set; }



    }
}
