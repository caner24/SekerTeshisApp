using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.DTO
{
    public record ForgottenPasswordDto
    {
        public  string MailAdress { get; init; }
    }
}
