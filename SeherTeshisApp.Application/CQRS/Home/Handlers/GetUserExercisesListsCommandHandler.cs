using MediatR;
using Microsoft.EntityFrameworkCore;
using SekerTeshis.Entity.Exceptions;
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
    public class GetUserExercisesListsCommandHandler : IRequestHandler<GetUserExercisesRequest, GetUserExercisesResponse>
    {
        private readonly IExercisesDal _exercisesDal;
        private readonly IDiabetesDetailDal _diabetesDetailDal;
        public GetUserExercisesListsCommandHandler(IExercisesDal exercisesDal, IDiabetesDetailDal diabetesDetailDal)
        {
            _exercisesDal = exercisesDal;
            _diabetesDetailDal = diabetesDetailDal;
        }
        public async Task<GetUserExercisesResponse> Handle(GetUserExercisesRequest request, CancellationToken cancellationToken)
        {
            var diabetesDetail = await _diabetesDetailDal.GetByIdentity(x => x.DiabetesId == request.UserId).OrderBy(x => x.Id).AsNoTracking().LastOrDefaultAsync();
            if (diabetesDetail == null)
                throw new UserNotFoundException();

            var exercisesList = await _exercisesDal.GetByIdentity(x => x.DiabetesDetailId == diabetesDetail.Id).OrderByDescending(x => x.Id).Take(2).AsNoTracking().ToListAsync();
            return new GetUserExercisesResponse { Exercises = exercisesList };
        }
    }
}
