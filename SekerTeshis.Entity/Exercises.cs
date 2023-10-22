using SekerTeshis.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity
{
    public class Exercises : IEntity
    {
        public int Id { get; set; }
        public string? ExercisesType { get; set; }
        public string? ExcersiesImgPath { get; set; }
        public DiabetesDetail? DiabetDetail { get; set; }
    }
}
