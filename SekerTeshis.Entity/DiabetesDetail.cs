using SekerTeshis.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity
{
    public class DiabetesDetail : IEntity
    {
        public DiabetesDetail()
        {
            Food = new Food();
            Exercises = new Exercises();
        }
        public int Id { get; set; }
        public enum Situation
        {
            Low,
            Normal,
            High
        }
        public enum MeasureType
        {
            Hungery,
            Satiety
        }
        public DateTime MeasureDate { get; set; }
        public int DiabetesId { get; set; }
        public Diabetes? Diabetes { get; set; }
        public Food Food { get; set; }
        public Exercises Exercises { get; set; }
    }
}
