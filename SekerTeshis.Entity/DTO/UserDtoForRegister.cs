using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.DTO
{
    public record UserDtoForRegister : UserDtoForManipulation
    {
        public string UserName { get; init; }
    }
}
