using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeherTeshisApp.Application.Account.Responses
{
    public class CreateUserResponse
    {
        public IdentityResult IsCreated { get; set; }

        public string Token { get; set; }

    }
}
