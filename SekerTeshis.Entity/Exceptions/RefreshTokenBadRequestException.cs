using SekerTeshis.Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.Exception
{
    public class RefreshTokenBadRequestException : BadRequestException
    {
        public RefreshTokenBadRequestException() : base($"Invalid client request. The tokenDto has some invalid values.")
        {
        }
    }
}
