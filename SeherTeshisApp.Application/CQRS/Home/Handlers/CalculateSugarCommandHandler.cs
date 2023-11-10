using AutoMapper;
using MediatR;
using SekerTeshis.Entity;
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
    public class CalculateSugarCommandHandler : IRequestHandler<CalculateSugarRequest, CalculateSugarResponse>
    {
        private readonly IDiabetesDetailDal _diabetesDetailDal;
        private readonly IMapper _mapper;
        public CalculateSugarCommandHandler(IDiabetesDetailDal diabetesDetail, IMapper mapper)
        {
            _diabetesDetailDal = diabetesDetail;
            _mapper = mapper;
        }
        async Task<CalculateSugarResponse> IRequestHandler<CalculateSugarRequest, CalculateSugarResponse>.Handle(CalculateSugarRequest request, CancellationToken cancellationToken)
        {
            if (request.MeasureType == "Hungry")
            {
                var durum = request.MeasureValue switch
                {
                    < 70 => "Hipoglisemi",
                    < 100 => "Normal",
                    <= 125 => "Gizli Şeker",
                    >= 126 => "Diyabet",
                };
                var diabetesDetail = _mapper.Map<DiabetesDetail>(request);
                diabetesDetail.Situation = durum;
                diabetesDetail.MeasureDate = DateTime.Now;
                var diabetes = await _diabetesDetailDal.AddAsync(diabetesDetail);
                return new CalculateSugarResponse { DateTime = DateTime.Now, Type = durum, };
            }
            else if (request.MeasureType == "Full")
            {
                var durum = request.MeasureValue switch
                {
                    < 140 => "Normal",
                    <= 199 => "Gizli Şeker",
                    >= 200 => "Diyabet",
                };
                var diabetesDetail = _mapper.Map<DiabetesDetail>(request);
                diabetesDetail.Situation = durum;
                await _diabetesDetailDal.AddAsync(diabetesDetail);
                return new CalculateSugarResponse { DateTime = DateTime.Now, Type = durum, };
            }
            else
                throw new Exception("Böyle bir şeker ölçümü yapilamamakta !.");
        }
    }
}
