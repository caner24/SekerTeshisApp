﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Account.Responses
{
    public class ForgottenPasswordResponse
    {
        public string Token { get; set; }
        public string MailAdress { get; set; }
    }
}
