using MediatR;
using Microsoft.EntityFrameworkCore;
using SekerTeshis.Entity;
using SekerTeshis.Entity.Helpers;
using SekerTeshisApp.Application.CQRS.Admin.Requests;
using SekerTeshisApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Admin.Handlers
{
    public class GetUserCommandHandler : IRequestHandler<GetUsersRequest, PagedList<Entity>>
    {
        private readonly IDiabetesDetailDal _diabetesDetailDal;
        private readonly ISortHelper<DiabetesDetail> _sortHelper;
        private readonly IDataSharper<DiabetesDetail> _dataShaper;
        public GetUserCommandHandler(IDiabetesDetailDal diabetesDetailDal, ISortHelper<DiabetesDetail> sortHelper, IDataSharper<DiabetesDetail> dataShaper)
        {
            _diabetesDetailDal = diabetesDetailDal;
            _sortHelper = sortHelper;
            _dataShaper = dataShaper;
        }
        public async Task<PagedList<Entity>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var diabetesDetails = _diabetesDetailDal.GetAll(x => DateOnly.FromDateTime(x.MeasureDate) > request.MinCreatedDate && DateOnly.FromDateTime(x.MeasureDate) <= request.MaxCreatedDate);
            SearchByName(ref diabetesDetails, request.DiabetesName);
            var sortedOwners = _sortHelper.ApplySort(diabetesDetails, request.OrderBy);
            var shapedOwners = _dataShaper.ShapeData(sortedOwners, request.Fields);

            return PagedList<Entity>.ToPagedList(shapedOwners,
             request.PageNumber,
             request.PageSize);
        }

        private void SearchByName(ref IQueryable<DiabetesDetail> owners, string DiabetesName)
        {
            if (!owners.Any() || string.IsNullOrWhiteSpace(DiabetesName))
                return;

            if (string.IsNullOrEmpty(DiabetesName))
                return;

            owners = owners.Where(o => o.Situation.ToLowerInvariant().Contains(DiabetesName.Trim().ToLowerInvariant()));
        }
    }
}
