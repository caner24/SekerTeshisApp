using MediatR;
using Microsoft.EntityFrameworkCore;
using SekerTeshis.Entity.Exceptions;
using SekerTeshisApp.Application.CQRS.Admin.Requests;
using SekerTeshisApp.Application.CQRS.Admin.Responses;
using SekerTeshisApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Admin.Handlers
{
    public class GetUserByIdentityCommandHandler : IRequestHandler<GetUserByIdentityRequest, GetUserByIdentityResponse>
    {

        private readonly IDiabetesDetailDal _diabetesDetailDal;
        public GetUserByIdentityCommandHandler(IDiabetesDetailDal diabetesDetailDal)
        {
            _diabetesDetailDal = diabetesDetailDal;
        }

        async Task<GetUserByIdentityResponse> IRequestHandler<GetUserByIdentityRequest, GetUserByIdentityResponse>.Handle(GetUserByIdentityRequest request, CancellationToken cancellationToken)
        {
            var diabetesDetail = await _diabetesDetailDal.GetAll(x => x.DiabetesId == request.UserId).Include(x => x.Diabetes).ThenInclude(x => x.User).AsNoTracking().ToListAsync();
            if (diabetesDetail == null)
                throw new NotFoundException();

            return new GetUserByIdentityResponse { DiabetesDetail = diabetesDetail };
        }
    }
}
