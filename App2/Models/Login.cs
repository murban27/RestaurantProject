﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    [Serializable]
    public class Login
    {

        public long Id { get; set; }
        public string Login1 { get; set; }
        public string Password { get; set; }
        public long IdPozice { get; set; }

        public virtual Pozice IdPoziceNavigation { get; set; }



    }
}
