using SekerTeshis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.Healthy
{
    public static class GenerateFoodList
    {
        public static List<Food> FoodListBreakFast = new List<Food>
        {
            new Food{FoodName="Yulaf ezmesi",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=350},
              new Food{FoodName="Yumurta beyazı omlet",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=300},
                new Food{FoodName="Yoğurt, taze meyve ve granola",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=300},
                  new Food{FoodName="Smoothie (süt, muz, yaban mersini ve chia tohumu)",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=350},
                    new Food{FoodName="Kepekli ekmek üzerine avokado dilimleri",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=300},
                      new Food{FoodName="Yumurta, domates ve ıspanaklı omlet",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=350},
                        new Food{FoodName="Smoothie bowl (süt, muz, çilek ve granola)",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=300}

        };

        public static List<Food> FoodListLunch = new List<Food>
        {
            new Food{FoodName="Havuç ve humus",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=150},
            new Food{FoodName="Tam buğday kraker ve lor peyniri",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=200},
                    new Food{FoodName="Ceviz içeren yoğurt",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=200},
                                        new Food{FoodName="Yoğurt ve taze meyve",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=150},
                                                            new Food{FoodName="Ceviz içeren yoğurt",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=200},


        };

        public static List<Food> FoodListDinner = new List<Food>
        {
 new Food{FoodName="Somon, kahverengi pirinç ve buharda brokoli",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=450},
              new Food{FoodName="Tavuk fajita ve karışık sebzeler",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=400},
                new Food{FoodName="Izgara hindi, bulgur pilavı ve yeşil salata",FoodImgUrl="yulaf_ezmesi.jpg" ,Calories=400},


        };
    }
}
