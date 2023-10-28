using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.Exceptions
{
    public class EmailNotConfirm : System.Exception
    {
        public EmailNotConfirm() : base(" Lütfen Mail Adresinizi Onaylayin !.")
        {

        }
    }
}
