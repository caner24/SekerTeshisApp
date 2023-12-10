using MediatR;
using SekerTeshisApp.Application.CQRS.Admin.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Admin.Requests
{
    public record GetUserByIdentityRequest : IRequest<GetUserByIdentityResponse>
    {
        public string UserId { get; init; }
    }
}
