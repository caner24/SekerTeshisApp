﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Account.Responses
{
    public class ResetPasswordResponse
    {
        public IdentityResult Result { get; set; }

        public string Message { get; set; }

    }
}
