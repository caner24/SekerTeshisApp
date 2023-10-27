using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.Exceptions
{
    public abstract class IdentityException : System.Exception
    {

        protected IdentityException(string msg) : base(msg)
        {

        }

    }
}

