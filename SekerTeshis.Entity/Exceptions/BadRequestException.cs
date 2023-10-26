using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.Exceptions
{
    public abstract class BadRequestException :System.Exception
    {
        protected BadRequestException(string message) :
            base(message)
        {

        }
    }
}
