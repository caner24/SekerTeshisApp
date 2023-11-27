using MediatR;
using SekerTeshisApp.Application.CQRS.Home.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Home.Requests
{
    public record GetUserFoodListRequest : IRequest<GetUserFoodListsResponse>
    {
        public string UserId { get; init; }
    }
}
