using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.Exceptions
{
    public class EmailPasswordException : IdentityException
    {
        public EmailPasswordException() : base("Şifreniz veya kullanici adiniz hatali.")
        {
        }
    }
}
