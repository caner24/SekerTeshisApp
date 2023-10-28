using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.DTO
{
    public record ResetPasswordDto : TokenDtoForManipulation
    {
        public string Password { get; set; }
    }
}
