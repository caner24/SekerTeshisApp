using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.DTO
{
    public abstract record UserDtoForManipulation
    {
        public string Email { get; init; }
        public string Password { get; init; }

    }
}
