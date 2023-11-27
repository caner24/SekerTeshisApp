using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    public class GetUserFoodListCommandHandler : IRequestHandler<GetUserFoodListRequest, GetUserFoodListsResponse>
    {
        private readonly IFoodDal _foodDal;
        private readonly IDiabetesDetailDal _diabetesDetailDal;
        public GetUserFoodListCommandHandler(IDiabetesDetailDal diabetesDetail, IFoodDal foodDal)
        {
            _diabetesDetailDal = diabetesDetail;
            _foodDal = foodDal;
        }
        public async Task<GetUserFoodListsResponse> Handle(GetUserFoodListRequest request, CancellationToken cancellationToken)
        {
            var diabetesDetail = await _diabetesDetailDal.GetByIdentity(x => x.DiabetesId == request.UserId).OrderBy(x => x.Id).AsNoTracking().LastOrDefaultAsync();
            if (diabetesDetail == null)
                throw new UserNotFoundException();

            var foodList = await _foodDal.GetByIdentity(x => x.DiabetesDetailId == diabetesDetail.Id).OrderByDescending(x => x.Id).Take(3).AsNoTracking().ToListAsync();
            foodList.ForEach(x => x.FoodImgUrl = Path.Combine(Directory.GetCurrentDirectory(), "Images//FoodImages//" + x.FoodImgUrl));
            return new GetUserFoodListsResponse { FoodLists = foodList };
        }
    }
}
