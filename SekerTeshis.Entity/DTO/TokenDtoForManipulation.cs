using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.DTO
{
    public abstract record TokenDtoForManipulation
    {
        public string Mail { get; init; }
        public string Token { get; init; }

    }
}
