﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSI.Zimmer.UI.Web.Controller.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel() : base() { }

        public string Login
        {
            get;
            set;
        }

        public string Senha
        {
            get;
            set;
        }

    }
}
