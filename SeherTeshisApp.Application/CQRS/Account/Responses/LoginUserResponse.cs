using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Account.Responses
{
    public class LoginUserResponse
    {
        public string AccessToken { get; init; }
        public string RefreshToken { get; init; }
        public bool IsLoggedIn { get; set; }
    }
}
