using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.DTO
{
    public record ConfirmMailDto
    {
        public string Token { get; init; }

        public string Mail { get; init; }
    }
}
