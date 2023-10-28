using MediatR;
using SekerTeshis.Entity.DTO;
using SekerTeshisApp.Application.Account.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.Account.Requests
{
    public record ForgottenPasswordRequest : ForgottenPasswordDto, IRequest<ForgottenPasswordResponse>
    {

    }
}
