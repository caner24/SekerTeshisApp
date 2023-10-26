using MediatR;
using SeherTeshisApp.Application.Account.Responses;
using SekerTeshis.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeherTeshisApp.Application.Account.Requests
{
    public record CreateUserRequest : UserDtoForRegister, IRequest<CreateUserResponse>
    {

    }
}
