using SekerTeshis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.Healthy
{
    public static class GenerateFitnessList
    {
        public static List<Exercises> ExercisesList = new List<Exercises> {
        new Exercises{ExercisesType="20-30 dakika hafif tempolu yürüyüş.",ExcersiesImgPath="walking.jpg"},
                new Exercises{ExercisesType="20-30 dakika pilates.",ExcersiesImgPath="plates.jpg"},
                                new Exercises{ExercisesType="20-30 dakika esneme hareketleri.",ExcersiesImgPath="stretching.jpg"},
        };
    }
}
