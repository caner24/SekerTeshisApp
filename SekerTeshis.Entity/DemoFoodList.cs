using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity
{
    public class DemoFoodList
    {
        public DemoFoodList()
        {
            Breakfast = new List<Food>
            {
                new Food{FoodName="Yulaf ezmesi ve Süt",FoodImgUrl=Path.Combine(Directory.GetCurrentDirectory(), "Images\\FoodImages", "yulaf_ezmesi.jpg") },
                new Food{FoodName="Yumurta Omlet",FoodImgUrl="",Calories=160 },
                new Food{FoodName="Yoğurt ve Badem",FoodImgUrl="",Calories=250 },
                   new Food{FoodName="Tam Buğday Ekmeği ile Peynir",FoodImgUrl="",Calories=210 },
                    new Food{FoodName="Avokado ve Yumurta Salatası",FoodImgUrl="",Calories=255 },
                        new Food{FoodName="Cevizli Yoğurt",FoodImgUrl="",Calories=250},
                          new Food{FoodName="Tam Tahıllı Krakerler ve Somon",FoodImgUrl="",Calories=306 },
                              new Food{FoodName="Böğürtlenli Chia Puding",FoodImgUrl="",Calories=180 },
                                   new Food{FoodName="Tarçınlı Meyve Salatası",FoodImgUrl="",Calories=106 },
                                    new Food{FoodName="Lor Peynirli Tam Tahıllı Ekmek",FoodImgUrl="",Calories=286 },
            };
        }
        public List<Food> Breakfast { get; set; }
        public List<Food> Launch { get; set; }
        public List<Food> Evening { get; set; }
    }
}
