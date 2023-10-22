﻿using SekerTeshis.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity
{
    public class Food : IEntity
    {
        public int Id { get; set; }
        public string? FoodName { get; set; }
        public enum FoodType
        {
            Breakfast,
            Launch,
            Evening
        }
        public string? FoodImgUrl { get; set; }
        public nint Calories { get; set; }
        public DiabetesDetail? DiabetesDetail { get; set; }
    }
}
