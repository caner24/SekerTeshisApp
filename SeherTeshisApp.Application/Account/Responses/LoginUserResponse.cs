using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.Account.Responses
{
    public class LoginUserResponse
    {
        public String AccessToken { get; init; }
        public String RefreshToken { get; init; }

        public bool IsLoggedIn { get; set; }
    }
}
