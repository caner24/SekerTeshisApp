using Microsoft.AspNetCore.Identity;
using SekerTeshis.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity
{
    public class User : IdentityUser, IEntity
    {
        public User()
        {
            Diabetess = new Diabetes();
        }
        public Diabetes Diabetess { get; set; }
        public String? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
