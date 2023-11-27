using AutoMapper;
using MediatR;
using SekerTeshis.Entity;
using SekerTeshis.Entity.Exceptions;
using SekerTeshisApp.Application.CQRS.Home.Requests;
using SekerTeshisApp.Application.CQRS.Home.Responses;
using SekerTeshisApp.Application.Healthy;
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
        Random _rnd;
        public CalculateSugarCommandHandler(IDiabetesDetailDal diabetesDetail, IMapper mapper)
        {
            _rnd = new Random(0);
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
                diabetesDetail.Foods.Add(GenerateFoodList.FoodListBreakFast[_rnd.Next(6)]);
                diabetesDetail.Foods.Add(GenerateFoodList.FoodListLunch[_rnd.Next(3)]);
                diabetesDetail.Foods.Add(GenerateFoodList.FoodListDinner[_rnd.Next(2)]);

                diabetesDetail.Exercises.Add(GenerateFitnessList.ExercisesList[_rnd.Next(2)]);
                diabetesDetail.Exercises.Add(GenerateFitnessList.ExercisesList[_rnd.Next(2)]);

                await _diabetesDetailDal.AddAsync(diabetesDetail);
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
                diabetesDetail.MeasureDate = DateTime.Now;
                diabetesDetail.Foods.Add(GenerateFoodList.FoodListBreakFast[_rnd.Next(6)]);
                diabetesDetail.Foods.Add(GenerateFoodList.FoodListLunch[_rnd.Next(3)]);
                diabetesDetail.Foods.Add(GenerateFoodList.FoodListDinner[_rnd.Next(2)]);

                diabetesDetail.Exercises.Add(GenerateFitnessList.ExercisesList[_rnd.Next(2)]);
                diabetesDetail.Exercises.Add(GenerateFitnessList.ExercisesList[_rnd.Next(2)]);

                await _diabetesDetailDal.AddAsync(diabetesDetail);
                return new CalculateSugarResponse { DateTime = DateTime.Now, Type = durum, };
            }
            else
                throw new Exception("Böyle bir şeker ölçümü yapilamamakta !.");
        }
    }
}
