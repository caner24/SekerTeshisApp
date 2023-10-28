using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.Exceptions
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException() : base($"Böyle bir email adresine kayitli kullanici bulunamadi !.")
        {

        }
    }
}
