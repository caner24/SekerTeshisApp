using MediatR;
using Microsoft.EntityFrameworkCore;
using SekerTeshisApp.Application.CQRS.Home.Requests;
using SekerTeshisApp.Application.CQRS.Home.Responses;
using SekerTeshisApp.Data.Abstract;
using SekerTeshisApp.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Home.Handlers
{
    public class Last7DiabetesCommandHandler : IRequestHandler<Last7DiabetesRequest, Last7DiabetesResponse>
    {
        private readonly IDiabetesDetailDal _diabetesDetailDal;
        public Last7DiabetesCommandHandler(IDiabetesDetailDal diabetesDetailDal)
        {
            _diabetesDetailDal = diabetesDetailDal;
        }
        async Task<Last7DiabetesResponse> IRequestHandler<Last7DiabetesRequest, Last7DiabetesResponse>.Handle(Last7DiabetesRequest request, CancellationToken cancellationToken)
        {
            var diabetesDetail = await _diabetesDetailDal.GetAll(x => x.DiabetesId == request.UserId).OrderBy(x => x.MeasureDate).Take(7).AsNoTracking().ToListAsync();
            if (diabetesDetail == null)
            {
                throw new Exception("Ölçüm değerleri bulunamadi");
            }
            return new Last7DiabetesResponse { DiabetesDetail = diabetesDetail };
        }
    }
}
