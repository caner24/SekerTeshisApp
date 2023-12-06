using MediatR;
using SekerTeshis.Entity.Helpers;
using SekerTeshis.Entity;
using SekerTeshis.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Admin.Requests
{
    public class GetUsersRequest : DiabetesDetailParameters, IRequest<PagedList<Entity>>
    {

    }
}
