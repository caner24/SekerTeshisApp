using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.Exceptions
{
    public class UserNotFoundException : IdentityException
    {
        public UserNotFoundException() : base(" Bu id numarasına sahip bir kullanici bulunamadi. ")
        {
        }
    }
}
