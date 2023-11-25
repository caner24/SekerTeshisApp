using MediatR;
using Microsoft.EntityFrameworkCore;
using SekerTeshis.Entity.Exceptions;
using SekerTeshisApp.Application.CQRS.Home.Requests;
using SekerTeshisApp.Application.CQRS.Home.Responses;
using SekerTeshisApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Home.Handlers
{
    public class IsUserLockDownCommandHandler : IRequestHandler<IsUserLockDownRequest, IsUserLockDownResponse>
    {
        private readonly IDiabetesDetailDal _diabetesDetailDal;
        public IsUserLockDownCommandHandler(IDiabetesDetailDal diabetesDetail)
        {
            _diabetesDetailDal = diabetesDetail;
        }
        public async Task<IsUserLockDownResponse> Handle(IsUserLockDownRequest request, CancellationToken cancellationToken)
        {
            var diabetesDetail = await _diabetesDetailDal.GetByIdentity(x => x.DiabetesId == request.Id).OrderBy(x => x.MeasureDate).LastOrDefaultAsync();
            if (diabetesDetail != null)
            {
                if (diabetesDetail.MeasureDate.AddHours(7) <= DateTime.UtcNow)
                    return new IsUserLockDownResponse { IsLockDown = false };
                else
                    return new IsUserLockDownResponse { IsLockDown = true };
            }
            throw new NotFoundException();

        }
    }
}
