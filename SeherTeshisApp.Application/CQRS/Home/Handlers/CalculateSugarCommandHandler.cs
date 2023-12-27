using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly IDiabetesDal _diabetesDal;
        private readonly IMapper _mapper;
        Random _rnd;
        private string _morning, _afternoon, _evening;
        private string _afternoonExercises, _eveningExercises;
        public CalculateSugarCommandHandler(IDiabetesDetailDal diabetesDetail, IDiabetesDal diabetesDal, IMapper mapper)
        {
            _rnd = new Random(0);

            _diabetesDetailDal = diabetesDetail;
            _diabetesDal = diabetesDal;
            _mapper = mapper;
        }
        async Task<CalculateSugarResponse> IRequestHandler<CalculateSugarRequest, CalculateSugarResponse>.Handle(CalculateSugarRequest request, CancellationToken cancellationToken)
        {
            var userEmail = await _diabetesDal.GetByIdentity(x => x.Id == request.DiabetesId).Include(x => x.User).Select(x => x.User.Email).AsNoTracking().FirstOrDefaultAsync();
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
                diabetesDetail.Foods.Clear();
                diabetesDetail.Exercises.Clear();
                diabetesDetail.Situation = durum;
                diabetesDetail.MeasureDate = DateTime.Now;

                diabetesDetail.Foods.Add(new Food { FoodName = GenerateFoodList.FoodListBreakFast[_rnd.Next(6)].FoodName, Calories = GenerateFoodList.FoodListBreakFast[_rnd.Next(6)].Calories, FoodImgUrl = GenerateFoodList.FoodListBreakFast[_rnd.Next(6)].FoodImgUrl });
                diabetesDetail.Foods.Add(new Food { FoodName = GenerateFoodList.FoodListBreakFast[_rnd.Next(3)].FoodName, Calories = GenerateFoodList.FoodListBreakFast[_rnd.Next(3)].Calories, FoodImgUrl = GenerateFoodList.FoodListBreakFast[_rnd.Next(3)].FoodImgUrl });
                diabetesDetail.Foods.Add(new Food { FoodName = GenerateFoodList.FoodListBreakFast[_rnd.Next(2)].FoodName, Calories = GenerateFoodList.FoodListBreakFast[_rnd.Next(2)].Calories, FoodImgUrl = GenerateFoodList.FoodListBreakFast[_rnd.Next(2)].FoodImgUrl });

                diabetesDetail.Exercises.Add(new Exercises { ExercisesType = GenerateFitnessList.ExercisesList[_rnd.Next(2)].ExercisesType, ExcersiesImgPath = GenerateFitnessList.ExercisesList[_rnd.Next(2)].ExcersiesImgPath });
                diabetesDetail.Exercises.Add(new Exercises { ExercisesType = GenerateFitnessList.ExercisesList[_rnd.Next(2)].ExercisesType, ExcersiesImgPath = GenerateFitnessList.ExercisesList[_rnd.Next(2)].ExcersiesImgPath });

                _morning = diabetesDetail.Foods[0].FoodName;
                _afternoon = diabetesDetail.Foods[1].FoodName;
                _evening = diabetesDetail.Foods[2].FoodName;

                _afternoonExercises = diabetesDetail.Exercises[0].ExercisesType;
                _eveningExercises = diabetesDetail.Exercises[1].ExercisesType;

                var addedEntity = await _diabetesDetailDal.AddAsync(diabetesDetail);
                return new CalculateSugarResponse { DateTime = DateTime.Now, Type = durum, MailAdress = userEmail, Morning = _morning, Afternoon = _afternoon, Evening = _evening, AfternoonExercises = _afternoonExercises, EveningExercises = _eveningExercises };


            }
            else if (request.MeasureType == "Full")
            {
                var durum = request.MeasureValue switch
                {
                    <= 140 => "Normal",
                    <= 199 => "Gizli Şeker",
                    >= 200 => "Diyabet",
                };
                var diabetesDetail = _mapper.Map<DiabetesDetail>(request);
                diabetesDetail.Foods.Clear();
                diabetesDetail.Exercises.Clear();
                diabetesDetail.Situation = durum;
                diabetesDetail.MeasureDate = DateTime.Now;

                diabetesDetail.Foods.Add(new Food { FoodName = GenerateFoodList.FoodListBreakFast[_rnd.Next(6)].FoodName, Calories = GenerateFoodList.FoodListBreakFast[_rnd.Next(6)].Calories, FoodImgUrl = GenerateFoodList.FoodListBreakFast[_rnd.Next(6)].FoodImgUrl });
                diabetesDetail.Foods.Add(new Food { FoodName = GenerateFoodList.FoodListBreakFast[_rnd.Next(3)].FoodName, Calories = GenerateFoodList.FoodListBreakFast[_rnd.Next(3)].Calories, FoodImgUrl = GenerateFoodList.FoodListBreakFast[_rnd.Next(3)].FoodImgUrl });
                diabetesDetail.Foods.Add(new Food { FoodName = GenerateFoodList.FoodListBreakFast[_rnd.Next(2)].FoodName, Calories = GenerateFoodList.FoodListBreakFast[_rnd.Next(2)].Calories, FoodImgUrl = GenerateFoodList.FoodListBreakFast[_rnd.Next(2)].FoodImgUrl });

                diabetesDetail.Exercises.Add(new Exercises { ExercisesType = GenerateFitnessList.ExercisesList[_rnd.Next(2)].ExercisesType, ExcersiesImgPath = GenerateFitnessList.ExercisesList[_rnd.Next(2)].ExcersiesImgPath });
                diabetesDetail.Exercises.Add(new Exercises { ExercisesType = GenerateFitnessList.ExercisesList[_rnd.Next(2)].ExercisesType, ExcersiesImgPath = GenerateFitnessList.ExercisesList[_rnd.Next(2)].ExcersiesImgPath });

                _morning = diabetesDetail.Foods[0].FoodName;
                _afternoon = diabetesDetail.Foods[1].FoodName;
                _evening = diabetesDetail.Foods[2].FoodName;

                _afternoonExercises = diabetesDetail.Exercises[0].ExercisesType;
                _eveningExercises = diabetesDetail.Exercises[1].ExercisesType;

                var addedEntity = await _diabetesDetailDal.AddAsync(diabetesDetail);
                return new CalculateSugarResponse { DateTime = DateTime.Now, Type = durum, MailAdress = userEmail, Morning = _morning, Afternoon = _afternoon, Evening = _evening, AfternoonExercises = _afternoonExercises, EveningExercises = _eveningExercises };
            }
            else
                throw new Exception("Böyle bir şeker ölçümü yapilamamakta !.");
        }
    }
}
