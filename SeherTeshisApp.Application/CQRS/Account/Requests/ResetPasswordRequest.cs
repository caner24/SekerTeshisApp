using MediatR;
using SekerTeshis.Entity.DTO;
using SekerTeshisApp.Application.CQRS.Account.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Account.Requests
{
    public record ResetPasswordRequest : ResetPasswordDto, IRequest<ResetPasswordResponse>
    {
    }
}
